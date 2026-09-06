using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setChatMenuButton</c> method.
/// </summary>
public sealed class SetChatMenuButtonParameters : ApiRequestParameters
{
    public long? ChatId { get; init; }

    public MenuButton? MenuButton { get; init; }
}
