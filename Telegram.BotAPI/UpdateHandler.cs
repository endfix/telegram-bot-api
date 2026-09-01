using System.Threading;
using System.Threading.Tasks;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI;

/// <summary>
/// Handles an update received by long polling.
/// </summary>
public delegate Task UpdateHandler(
    IBotApiClient client,
    Update update,
    CancellationToken cancellationToken);
