namespace Endfix.Telegram.BotAPI.Types;

public sealed class ChatInviteLink
{
    public required string InviteLink { get; init; }

    public required User Creator { get; init; }

    public required bool CreatesJoinRequest { get; init; }

    public required bool IsPrimary { get; init; }

    public required bool IsRevoked { get; init; }

    public string? Name { get; init; }

    public int? ExpireDate { get; init; }

    public int? MemberLimit { get; init; }

    public int? PendingJoinRequestCount { get; init; }

    public int? SubscriptionPeriod { get; init; }

    public int? SubscriptionPrice { get; init; }
}
