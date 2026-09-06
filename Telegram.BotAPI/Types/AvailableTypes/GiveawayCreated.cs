namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes a service message about the creation of a scheduled giveaway.</summary>
public sealed class GiveawayCreated
{
    /// <summary>Optional. Number of Telegram Stars to be split between giveaway winners, for Telegram Star giveaways only.</summary>
    public int? PrizeStarCount { get; init; }
}
