namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes a service message about the completion of a giveaway without public winners.</summary>
public sealed class GiveawayCompleted
{
    /// <summary>Number of winners in the giveaway.</summary>
    public required int WinnerCount { get; init; }

    /// <summary>Optional. Number of undistributed prizes.</summary>
    public int? UnclaimedPrizeCount { get; init; }

    /// <summary>Optional. Message containing the completed giveaway, if it was not deleted.</summary>
    public Message? GiveawayMessage { get; init; }

    /// <summary>Optional. Indicates that the giveaway was a Telegram Star giveaway.</summary>
    public bool? IsStarGiveaway { get; init; }
}
