using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>sendChatJoinRequestWebApp</c> method.
/// </summary>
public sealed class SendChatJoinRequestWebAppParameters : ApiRequestParameters
{
    public required string ChatJoinRequestQueryId { get; init; }

    public required string WebAppUrl { get; init; }
}
