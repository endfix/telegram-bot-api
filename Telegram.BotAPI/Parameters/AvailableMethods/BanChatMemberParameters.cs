using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>banChatMember</c> method.
/// </summary>
public sealed class BanChatMemberParameters : ApiRequestParameters
{
    /// <summary>Gets the unique identifier or username of the target group, supergroup, or channel.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>Gets the unique identifier of the user to ban.</summary>
    public required long UserId { get; init; }

    /// <summary>Gets the Unix time when the user will be unbanned. Values less than 30 seconds or more than 366 days from the current time represent a permanent ban.</summary>
    public int? UntilDate { get; init; }

    /// <summary>Gets whether to delete all messages from the chat sent by the user. This value is always <see langword="true"/> for supergroups and channels.</summary>
    public bool? RevokeMessages { get; init; }
}
