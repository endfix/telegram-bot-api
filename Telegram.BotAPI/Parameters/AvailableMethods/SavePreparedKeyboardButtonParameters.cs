using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class SavePreparedKeyboardButtonParameters : ApiRequestParameters
{
    public required long UserId { get; init; }

    public required KeyboardButton Button { get; init; }
}
