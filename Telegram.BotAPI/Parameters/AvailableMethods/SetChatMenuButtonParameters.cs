using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class SetChatMenuButtonParameters : ApiRequestParameters
{
    public long? ChatId { get; init; }

    public MenuButton? MenuButton { get; init; }
}
