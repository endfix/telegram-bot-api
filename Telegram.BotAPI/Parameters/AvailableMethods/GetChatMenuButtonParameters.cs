using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>getChatMenuButton</c> method.
/// </summary>
public sealed class GetChatMenuButtonParameters : ApiRequestParameters
{
    /// <summary>Target private chat identifier. Omit it to return the default menu button.</summary>
    public long? ChatId { get; init; }
}
