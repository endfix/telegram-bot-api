using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes a scheduled giveaway message.</summary>
public sealed class Giveaway
{
    /// <summary>Chats that users must join to participate in the giveaway.</summary>
    public required IReadOnlyList<Chat> Chats { get; init; }

    /// <summary>Unix time when giveaway winners will be selected.</summary>
    public required int WinnersSelectionDate { get; init; }

    /// <summary>Number of users to be selected as winners.</summary>
    public required int WinnerCount { get; init; }

    /// <summary>Optional. Indicates that only users who join after the giveaway starts are eligible.</summary>
    public bool? OnlyNewMembers { get; init; }

    /// <summary>Optional. Indicates that the list of winners will be visible to everyone.</summary>
    public bool? HasPublicWinners { get; init; }

    /// <summary>Optional. Description of an additional giveaway prize.</summary>
    public string? PrizeDescription { get; init; }

    /// <summary>Optional. Two-letter ISO 3166-1 alpha-2 country codes from which eligible users must come.</summary>
    public IReadOnlyList<string>? CountryCodes { get; init; }

    /// <summary>Optional. Number of Telegram Stars to be split between giveaway winners, for Telegram Star giveaways only.</summary>
    public int? PrizeStarCount { get; init; }

    /// <summary>Optional. Number of months the Telegram Premium subscription won from the giveaway will be active for.</summary>
    public int? PremiumSubscriptionMonthCount { get; init; }
}
