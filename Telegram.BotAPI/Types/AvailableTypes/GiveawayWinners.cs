using System.Collections.Generic;

namespace Telegram.BotAPI.Types;

public sealed class GiveawayWinners
{
    public required Chat Chat { get; init; }

    public required int GiveawayMessageId { get; init; }

    public required int WinnersSelectionDate { get; init; }

    public required int WinnerCount { get; init; }

    public required IReadOnlyList<User> Winners { get; init; }

    public int? AdditionalChatCount { get; init; }

    public int? PremiumSubscriptionMonthCount { get; init; }

    public int? UnclaimedPrizeCount { get; init; }

    public bool? OnlyNewMembers { get; init; }

    public bool? WasRefunded { get; init; }

    public string? PrizeDescription { get; init; }
}
