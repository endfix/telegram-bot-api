using System.Threading;
using System.Threading.Tasks;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI;

/// <summary>
/// Handles an update received by long polling.
/// </summary>
/// <param name="client">Bot API client that received the update.</param>
/// <param name="update">Update to process.</param>
/// <param name="cancellationToken">Token that signals that the polling session is stopping.</param>
/// <returns>A task that represents the asynchronous update handling operation.</returns>
public delegate Task UpdateHandler(
    IBotApiClient client,
    Update update,
    CancellationToken cancellationToken);
