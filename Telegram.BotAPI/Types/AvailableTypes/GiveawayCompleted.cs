namespace Telegram.BotAPI.Types.AvailableTypes;

public sealed class GiveawayCompleted
{
    public int WinnerCount { get; set; }

    public int UnclaimedPrizeCount { get; set; }

    public Message GiveawayMessage { get; set; }
}
