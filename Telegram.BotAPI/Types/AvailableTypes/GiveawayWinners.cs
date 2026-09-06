using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes a message about the completion of a giveaway with public winners.</summary>
public sealed class GiveawayWinners
{
    /// <summary>Chat that created the giveaway.</summary>
    public required Chat Chat { get; init; }

    /// <summary>Identifier of the giveaway message in the chat.</summary>
    public required long GiveawayMessageId { get; init; }

    /// <summary>Unix time when the winners were selected.</summary>
    public required long WinnersSelectionDate { get; init; }

    /// <summary>Total number of winners in the giveaway.</summary>
    public required int WinnerCount { get; init; }

    /// <summary>List of up to 100 giveaway winners.</summary>
    public required IReadOnlyList<User> Winners { get; init; }

    /// <summary>Optional. Number of other chats users had to join to participate.</summary>
    public int? AdditionalChatCount { get; init; }

    /// <summary>Optional. Number of Telegram Stars split between the winners, for Telegram Star giveaways only.</summary>
    public int? PrizeStarCount { get; init; }

    /// <summary>Optional. Number of months the Telegram Premium subscription won from the giveaway will be active for.</summary>
    public int? PremiumSubscriptionMonthCount { get; init; }

    /// <summary>Optional. Number of undistributed prizes.</summary>
    public int? UnclaimedPrizeCount { get; init; }

    /// <summary>Optional. Indicates that only users who joined after the giveaway started were eligible.</summary>
    public bool? OnlyNewMembers { get; init; }

    /// <summary>Optional. Indicates that the giveaway was canceled because its payment was refunded.</summary>
    public bool? WasRefunded { get; init; }

    /// <summary>Optional. Description of an additional giveaway prize.</summary>
    public string? PrizeDescription { get; init; }
}
