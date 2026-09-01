using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI;

public interface IBotApiClient
{
    /// <summary>
    /// Raised for each update received by long polling. Subscribers are invoked
    /// in registration order and each returned task is awaited.
    /// </summary>
    event BotApiClient.UpdateHandler? OnUpdate;

    Task<T> ExecuteAsync<T>(ApiRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Starts best-effort long polling until cancellation is requested.
    /// Handler failures are logged and do not cause automatic redelivery. Only
    /// one polling session can run on a client instance at a time.
    /// </summary>
    Task StartPollingAsync(
        int limit = 1,
        int timeout = 20,
        IReadOnlyList<UpdateType>? allowedUpdates = null,
        int maxParallel = 1,
        CancellationToken cancellationToken = default);
}
