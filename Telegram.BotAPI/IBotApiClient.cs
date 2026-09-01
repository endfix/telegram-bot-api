using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI;

public interface IBotApiClient
{
    /// <summary>
    /// Raised for each update received by long polling. Subscribers are invoked
    /// in registration order and each returned task is awaited. The cancellation
    /// token signals that the active polling session is stopping.
    /// </summary>
    event UpdateHandler? OnUpdate;

    Task<T> ExecuteAsync<T>(ApiRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Downloads a Telegram file and rejects unsuccessful HTTP responses.
    /// </summary>
    Task<byte[]> GetFileBytesAsync(string filePath, CancellationToken cancellation = default);

    /// <summary>
    /// Downloads the currencies supported by Telegram payments.
    /// </summary>
    Task<IReadOnlyDictionary<string, Currency>> GetCurrenciesAsync(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Starts best-effort long polling until cancellation is requested. Handler
    /// failures are logged and are not retried. An update may be delivered again
    /// if polling stops before a later request advances the offset. Only one polling
    /// session can run on a client instance at a time.
    /// </summary>
    Task StartPollingAsync(
        int limit = 1,
        int timeout = 20,
        IReadOnlyList<UpdateType>? allowedUpdates = null,
        int maxParallel = 1,
        CancellationToken cancellationToken = default);
}
