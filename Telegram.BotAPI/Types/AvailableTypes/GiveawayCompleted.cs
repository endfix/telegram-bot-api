namespace Endfix.Telegram.BotAPI.Types;

public sealed class GiveawayCompleted
{
    public required int WinnerCount { get; init; }

    public int? UnclaimedPrizeCount { get; init; }

    public Message? GiveawayMessage { get; init; }

    public bool? IsStarGiveaway { get; init; }
}
