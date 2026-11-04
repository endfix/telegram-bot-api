using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Exceptions;
using Endfix.Telegram.BotAPI.Extensions;
using Endfix.Telegram.BotAPI.Types;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;

namespace Endfix.Telegram.BotAPI;

public sealed partial class BotApiClient
{
    private int _pollingStarted;

    internal TimeSpan PollingRetryDelay { get; set; } = TimeSpan.FromSeconds(5);

    /// <summary>
    /// Starts best-effort long polling until cancellation is requested.
    /// Handler failures are logged and are not retried. Updates are confirmed
    /// only when a later <c>getUpdates</c> request advances the offset, so stopping
    /// before that request may cause an update to be delivered again. No checkpoint
    /// is persisted across polling sessions. Only one polling session can run on
    /// a client instance at a time.
    /// </summary>
    /// <remarks>
    /// Transient request timeouts and retryable Telegram errors are retried.
    /// Non-retryable <c>4xx</c> errors stop polling and are rethrown as
    /// <see cref="ApiRequestException"/>. Disposing the client also stops the session.
    /// </remarks>
    /// <param name="limit">Maximum number of updates retrieved per request, from 1 to 100.</param>
    /// <param name="timeout">
    /// Long-polling timeout in seconds; must be non-negative. Values not less than
    /// <c>HttpClient.Timeout</c> may be canceled by the HTTP client first.
    /// </param>
    /// <param name="allowedUpdates">
    /// Update types to receive, or <see langword="null"/> to use Telegram's current
    /// setting. <see cref="UpdateType.Unknown"/> is not allowed.
    /// </param>
    /// <param name="maxParallel">Maximum number of updates processed concurrently; must be at least 1.</param>
    /// <param name="cancellationToken">Token used to stop polling. Disposing the client also stops the session.</param>
    /// <returns>A task that completes when polling stops.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="limit"/>, <paramref name="timeout"/>, or <paramref name="maxParallel"/> is out of range.
    /// </exception>
    /// <exception cref="ArgumentException"><paramref name="allowedUpdates"/> contains <see cref="UpdateType.Unknown"/>.</exception>
    /// <exception cref="InvalidOperationException">Another polling session is already running.</exception>
    /// <exception cref="ObjectDisposedException">The client has been disposed.</exception>
    public async Task StartPollingAsync(
        int limit = 1,
        int timeout = 20,
        IReadOnlyList<UpdateType>? allowedUpdates = null,
        int maxParallel = 1,
        CancellationToken cancellationToken = default)
    {
        ThrowIfDisposed();

        if (limit is < 1 or > 100)
        {
            throw new ArgumentOutOfRangeException(
                nameof(limit),
                "The update limit must be between 1 and 100.");
        }

        if (timeout < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(timeout),
                "The long-polling timeout cannot be negative.");
        }

        if (maxParallel < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(maxParallel));
        }

        if (allowedUpdates is not null && allowedUpdates.Contains(UpdateType.Unknown))
        {
            throw new ArgumentException(
                "Allowed updates cannot contain UpdateType.Unknown.",
                nameof(allowedUpdates));
        }

        if (timeout > 0 &&
            _httpClient.Timeout != Timeout.InfiniteTimeSpan &&
            timeout >= _httpClient.Timeout.TotalSeconds)
        {
            _logger.LogWarning(
                "Long polling timeout {Timeout}s is not less than HttpClient.Timeout {HttpTimeout}s; " +
                "the HTTP client may cancel the polling request before Telegram responds.",
                timeout,
                _httpClient.Timeout.TotalSeconds);
        }

        if (Interlocked.CompareExchange(ref _pollingStarted, 1, 0) != 0)
        {
            throw new InvalidOperationException("Long polling is already running for this client.");
        }

        using var linkedCancellation = CancellationTokenSource.CreateLinkedTokenSource(
            cancellationToken,
            _disposeCts.Token);

        try
        {
            await RunPollingAsync(
                limit,
                timeout,
                allowedUpdates,
                maxParallel,
                linkedCancellation.Token).ConfigureAwait(false);
        }
        finally
        {
            Volatile.Write(ref _pollingStarted, 0);
        }
    }

    private async Task RunPollingAsync(
        int limit,
        int timeout,
        IReadOnlyList<UpdateType>? allowedUpdates,
        int maxParallel,
        CancellationToken cancellationToken)
    {
        using var throttling = new SemaphoreSlim(maxParallel, maxParallel);

        async Task ProcessUpdateAsync(Update update)
        {
            try
            {
                await throttling.WaitAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            try
            {
                await InvokeUpdateHandlersAsync(update, cancellationToken).ConfigureAwait(false);
            }
            catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
            {
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error processing update {Id}", update.UpdateId);
            }
            finally
            {
                throttling.Release();
            }
        }

        var lastUpdateId = 0L;

        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                var updates = await this.GetUpdatesAsync(
                    offset: lastUpdateId,
                    limit: limit,
                    timeout: timeout,
                    AllowedUpdates: allowedUpdates,
                    cancellationToken).ConfigureAwait(false);

                if (updates is { Count: > 0 })
                {
                    var tasks = new List<Task>();

                    foreach (var update in updates)
                    {
                        if (maxParallel == 1)
                        {
                            await ProcessUpdateAsync(update).ConfigureAwait(false);
                        }
                        else
                        {
                            tasks.Add(ProcessUpdateAsync(update));
                        }

                        lastUpdateId = update.UpdateId + 1;
                    }

                    if (maxParallel > 1)
                    {
                        await Task.WhenAll(tasks).ConfigureAwait(false);
                    }
                }
            }
            catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
            {
                break;
            }
            catch (OperationCanceledException e)
            {
                _logger.LogWarning(
                    e,
                    "Long polling request was canceled by the HTTP client " +
                    "(for example, by HttpClient.Timeout); retrying.");
                if (!await WaitBeforePollingRetryAsync(PollingRetryDelay, cancellationToken).ConfigureAwait(false))
                {
                    break;
                }
            }
            catch (ApiRequestException e)
            {
                if (IsFatalPollingError(e.ErrorCode))
                {
                    _logger.LogError(
                        e,
                        "Long polling stopped by a non-retryable Telegram error {ErrorCode}.",
                        e.ErrorCode);
                    throw;
                }

                _logger.LogWarning("Long Polling: {Message}", e.Message);
                var delay = e.Parameters?.RetryAfter is int retryAfter && retryAfter >= 0
                    ? TimeSpan.FromSeconds(retryAfter)
                    : PollingRetryDelay;

                if (!await WaitBeforePollingRetryAsync(delay, cancellationToken).ConfigureAwait(false))
                {
                    break;
                }
            }
            catch (ObjectDisposedException)
            {
                break;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Critical error loop of Long Polling");
                if (!await WaitBeforePollingRetryAsync(PollingRetryDelay, cancellationToken).ConfigureAwait(false))
                {
                    break;
                }
            }
        }
    }

    private async Task InvokeUpdateHandlersAsync(
        Update update,
        CancellationToken cancellationToken)
    {
        var handlers = OnUpdate?.GetInvocationList();
        if (handlers is null)
        {
            return;
        }

        List<Exception>? failures = null;

        foreach (UpdateHandler handler in handlers)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                break;
            }

            try
            {
                await handler(this, update, cancellationToken).ConfigureAwait(false);
            }
            catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
            {
                break;
            }
            catch (Exception exception)
            {
                failures ??= [];
                failures.Add(exception);
            }
        }

        if (failures is { Count: 1 })
        {
            ExceptionDispatchInfo.Capture(failures[0]).Throw();
        }

        if (failures is { Count: > 1 })
        {
            throw new AggregateException("Multiple update handlers failed.", failures);
        }
    }

    private static bool IsFatalPollingError(int errorCode)
        => errorCode >= 400 &&
           errorCode < 500 &&
           errorCode != 408 &&
           errorCode != 429;

    private static async Task<bool> WaitBeforePollingRetryAsync(
        TimeSpan delay,
        CancellationToken cancellationToken)
    {
        try
        {
            await Task.Delay(delay, cancellationToken).ConfigureAwait(false);
            return true;
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
            return false;
        }
    }
}
