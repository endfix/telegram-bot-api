namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents an invite link for a chat.</summary>
public sealed class ChatInviteLink
{
    /// <summary>Invite link.</summary>
    public required string InviteLink { get; init; }

    /// <summary>User who created the invite link.</summary>
    public required User Creator { get; init; }

    /// <summary>Indicates whether the link creates join requests.</summary>
    public required bool CreatesJoinRequest { get; init; }

    /// <summary>Indicates whether the link is the primary invite link.</summary>
    public required bool IsPrimary { get; init; }

    /// <summary>Indicates whether the link has been revoked.</summary>
    public required bool IsRevoked { get; init; }

    /// <summary>Invite link name, if available.</summary>
    public string? Name { get; init; }

    /// <summary>Point in time when the link will expire, in Unix time, if available.</summary>
    public int? ExpireDate { get; init; }

    /// <summary>Maximum number of users that can be members of the chat after joining via this link, if configured.</summary>
    public int? MemberLimit { get; init; }

    /// <summary>Number of pending join requests created by this link, if applicable.</summary>
    public int? PendingJoinRequestCount { get; init; }

    /// <summary>Duration of the subscription, in seconds, if the link is subscription-based.</summary>
    public int? SubscriptionPeriod { get; init; }

    /// <summary>Price of the subscription in Telegram Stars, if the link is subscription-based.</summary>
    public int? SubscriptionPrice { get; init; }
}
