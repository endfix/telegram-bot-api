using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>getUserChatBoosts</c> method.
/// </summary>
public sealed class GetUserChatBoostsParameters : ApiRequestParameters
{
    /// <summary>Target chat identifier or channel username.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>Target user identifier.</summary>
    public required long UserId { get; init; }
}
