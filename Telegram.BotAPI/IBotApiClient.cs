using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI;

/// <summary>
/// Common Bot API client surface intended for dependency injection and update handlers.
/// </summary>
public interface IBotApiClient
{
    /// <summary>
    /// Raised for each update received by long polling. Subscribers are invoked
    /// in registration order and each returned task is awaited. The cancellation
    /// token signals that the active polling session is stopping.
    /// </summary>
    event UpdateHandler? OnUpdate;

    /// <summary>
    /// Sends a request and returns its result, throwing <see cref="Exceptions.ApiRequestException"/>
    /// when Telegram returns an unsuccessful API response.
    /// </summary>
    /// <typeparam name="T">The expected result type.</typeparam>
    /// <param name="request">The request to send.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The successful Telegram API result.</returns>
    Task<T> ExecuteAsync<T>(ApiRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Downloads a Telegram file and rejects unsuccessful HTTP responses.
    /// </summary>
    /// <param name="filePath">Relative file path returned by <c>getFile</c>.</param>
    /// <param name="cancellation">Token used to cancel the download.</param>
    /// <returns>A byte array containing the complete file.</returns>
    Task<byte[]> GetFileBytesAsync(string filePath, CancellationToken cancellation = default);

    /// <summary>
    /// Downloads a Telegram file into a destination stream without buffering the complete file in memory.
    /// </summary>
    /// <remarks>The destination stream remains open and positioned after the downloaded content.</remarks>
    /// <param name="filePath">Relative file path returned by <c>getFile</c>.</param>
    /// <param name="destination">Writable stream that receives the file content.</param>
    /// <param name="cancellationToken">Token used to cancel the download.</param>
    /// <returns>A task that completes when the file has been written to the destination.</returns>
    Task DownloadFileAsync(
        string filePath,
        Stream destination,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Downloads the currencies supported by Telegram payments.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the download.</param>
    /// <returns>A dictionary of supported currencies keyed by ISO 4217 currency code.</returns>
    Task<IReadOnlyDictionary<string, Currency>> GetCurrenciesAsync(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Starts best-effort long polling until cancellation is requested. Handler
    /// failures are logged and are not retried. An update may be delivered again
    /// if polling stops before a later request advances the offset. Only one polling
    /// session can run on a client instance at a time.
    /// </summary>
    /// <param name="limit">Maximum number of updates retrieved per request, from 1 to 100.</param>
    /// <param name="timeout">Long-polling timeout in seconds.</param>
    /// <param name="allowedUpdates">Update types to receive, or <see langword="null"/> to use Telegram's current setting.</param>
    /// <param name="maxParallel">Maximum number of updates processed concurrently.</param>
    /// <param name="cancellationToken">Token used to stop polling.</param>
    /// <returns>A task that completes when polling stops.</returns>
    Task StartPollingAsync(
        int limit = 1,
        int timeout = 20,
        IReadOnlyList<UpdateType>? allowedUpdates = null,
        int maxParallel = 1,
        CancellationToken cancellationToken = default);
}
