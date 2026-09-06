using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>savePreparedKeyboardButton</c> method.
/// </summary>
public sealed class SavePreparedKeyboardButtonParameters : ApiRequestParameters
{
    public required long UserId { get; init; }

    public required KeyboardButton Button { get; init; }
}
