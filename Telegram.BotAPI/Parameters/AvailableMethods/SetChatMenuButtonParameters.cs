using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setChatMenuButton</c> method.
/// </summary>
public sealed class SetChatMenuButtonParameters : ApiRequestParameters
{
    /// <summary>Target private chat identifier. Omit it to change the default menu button.</summary>
    public long? ChatId { get; init; }

    /// <summary>New menu button. Defaults to Telegram's default menu button.</summary>
    public MenuButton? MenuButton { get; init; }
}
