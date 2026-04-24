using Telegram.BotAPI.Protocol;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class SetChatMenuButtonParameters : ApiRequestParameters
{
    public long? ChatId { get; init; }

    public MenuButton? MenuButton { get; init; }
}
