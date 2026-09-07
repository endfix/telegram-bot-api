using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>unbanChatMember</c> method.
/// </summary>
public sealed class UnbanChatMemberParameters : ApiRequestParameters
{
    /// <summary>Target group identifier or target supergroup or channel username.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>Target user identifier.</summary>
    public required long UserId { get; init; }

    /// <summary>Whether to do nothing when the user is not banned.</summary>
    public bool? OnlyIfBanned { get; init; }
}
