using System.Threading;
using System.Threading.Tasks;
using Telegram.BotAPI.Parameters;
using Telegram.BotAPI.Protocol;

namespace Telegram.BotAPI;

public interface IBotApiClient
{
    event BotApiClient.UpdateHandler? OnUpdate;

    Task<T> ExecuteAsync<T>(ApiRequest request, CancellationToken cancellationToken = default);

    Task StartPollingAsync(GetUpdatesParameters? parameters = null, int maxParallel = 10, CancellationToken cancellationToken = default);
}
