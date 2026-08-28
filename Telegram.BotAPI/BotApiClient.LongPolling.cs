using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Exceptions;
using Endfix.Telegram.BotAPI.Extensions;
using Endfix.Telegram.BotAPI.Types;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Endfix.Telegram.BotAPI;

public sealed partial class BotApiClient
{
    public delegate Task UpdateHandler(IBotApiClient client, Update update);

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

        using var throttling = new SemaphoreSlim(maxParallel, maxParallel);

        async Task ProcessUpdateAsync(Update update)
        {
            await throttling.WaitAsync(cancellationToken);

            try
            {
                if (OnUpdate is not null)
                {
                    await OnUpdate.Invoke(this, update);
                }
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
                await Task.Delay(5000, cancellationToken).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                break;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Critical error loop of Long Polling");
                await Task.Delay(5000, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
