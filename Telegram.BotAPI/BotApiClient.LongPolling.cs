using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Exceptions;
using Endfix.Telegram.BotAPI.Extensions;
using Endfix.Telegram.BotAPI.Types;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;

namespace Endfix.Telegram.BotAPI;

public sealed partial class BotApiClient
{
    private int _pollingStarted;

    /// <summary>
    /// Starts best-effort long polling until cancellation is requested.
    /// Handler failures are logged and are not retried. Updates are confirmed
    /// only when a later <c>getUpdates</c> request advances the offset, so stopping
    /// before that request may cause an update to be delivered again. No checkpoint
    /// is persisted across polling sessions. Only one polling session can run on
    /// a client instance at a time.
    /// </summary>
    public async Task StartPollingAsync(
        int limit = 1,
        int timeout = 20,
        IReadOnlyList<UpdateType>? allowedUpdates = null,
        int maxParallel = 1,
        CancellationToken cancellationToken = default)
    {
        if (maxParallel < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(maxParallel));
        }

        if (Interlocked.CompareExchange(ref _pollingStarted, 1, 0) != 0)
        {
            throw new InvalidOperationException("Long polling is already running for this client.");
        }

        try
        {
            await RunPollingAsync(
                limit,
                timeout,
                allowedUpdates,
                maxParallel,
                cancellationToken).ConfigureAwait(false);
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
            await throttling.WaitAsync(cancellationToken);

            try
            {
                await InvokeUpdateHandlersAsync(update, cancellationToken).ConfigureAwait(false);
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
                            await ProcessUpdateAsync(update);
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
            catch (ApiRequestException e)
            {
                _logger.LogWarning("Long Polling: {Message}", e.Message);
                if (!await WaitBeforePollingRetryAsync(cancellationToken).ConfigureAwait(false))
                {
                    break;
                }
            }
            catch (OperationCanceledException)
            {
                break;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Critical error loop of Long Polling");
                if (!await WaitBeforePollingRetryAsync(cancellationToken).ConfigureAwait(false))
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

    private static async Task<bool> WaitBeforePollingRetryAsync(CancellationToken cancellationToken)
    {
        try
        {
            await Task.Delay(5000, cancellationToken).ConfigureAwait(false);
            return true;
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
            return false;
        }
    }
}
