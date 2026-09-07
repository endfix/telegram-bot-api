using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>declineChatJoinRequest</c> method.
/// </summary>
public sealed class DeclineChatJoinRequestParameters : ApiRequestParameters
{
    /// <summary>Target chat identifier or channel username.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>Identifier of the user whose request is declined.</summary>
    public required long UserId { get; init; }
}
