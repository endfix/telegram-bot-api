using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI;

public interface IBotApiClient
{
    event BotApiClient.UpdateHandler? OnUpdate;

    Task<T> ExecuteAsync<T>(ApiRequest request, CancellationToken cancellationToken = default);

    Task StartPollingAsync(
        int limit = 1,
        int timeout = 20,
        IReadOnlyList<UpdateType>? allowedUpdates = null,
        int maxParallel = 1,
        CancellationToken cancellationToken = default);
}
