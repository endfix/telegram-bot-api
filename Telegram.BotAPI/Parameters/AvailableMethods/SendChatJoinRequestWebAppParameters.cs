using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>sendChatJoinRequestWebApp</c> method.
/// </summary>
public sealed class SendChatJoinRequestWebAppParameters : ApiRequestParameters
{
    /// <summary>Identifier of the join request query.</summary>
    public required string ChatJoinRequestQueryId { get; init; }

    /// <summary>HTTPS URL of the Mini App to open.</summary>
    public required string WebAppUrl { get; init; }
}
