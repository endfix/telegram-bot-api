using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>getChatMenuButton</c> method.
/// </summary>
public sealed class GetChatMenuButtonParameters : ApiRequestParameters
{
    public long? ChatId { get; init; }
}
