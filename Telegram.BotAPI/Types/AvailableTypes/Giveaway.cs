using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

public sealed class Giveaway
{
    public required IReadOnlyList<Chat> Chats { get; init; }

    public required int WinnersSelectionDate { get; init; }

    public required int WinnerCount { get; init; }

    public bool? OnlyNewMembers { get; init; }

    public bool? HasPublicWinners { get; init; }

    public string? PrizeDescription { get; init; }

    public IReadOnlyList<string>? CountryCodes { get; init; }

    public int? PremiumSubscriptionMonthCount { get; init; }
}
