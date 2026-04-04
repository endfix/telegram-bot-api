using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class SavePreparedKeyboardButtonParameters : ApiRequestParameters
{
    public required long UserId { get; init; }

    public required KeyboardButton Button { get; init; }
}
