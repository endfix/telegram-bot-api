using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class SetChatMenuButtonParameters : ApiRequestParameters
{
    public long ChatId { get; set; }

    public MenuButton MenuButton { get; set; }
}
