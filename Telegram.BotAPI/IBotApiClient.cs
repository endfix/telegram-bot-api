using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Telegram.BotAPI.Enums;
using Telegram.BotAPI.Protocol;

namespace Telegram.BotAPI;

public interface IBotApiClient
{
    event BotApiClient.UpdateHandler? OnUpdate;

    Task<T> ExecuteAsync<T>(ApiRequest request, CancellationToken cancellationToken = default);

    Task StartPollingAsync(
        int limit = 1, 
        int timeout = 20, 
        IReadOnlyList<UpdateType>? allowedUpdates = null, 
        int maxParallel = 10, 
        CancellationToken cancellationToken = default);
}
