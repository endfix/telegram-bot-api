namespace Telegram.BotAPI.Types;

public sealed class Giveaway
{
    public Chat[] Chats { get; set; }

    public int WinnersSelectionDate { get; set; }

    public int WinnerCount { get; set; }

    public bool OnlyNewMembers { get; set; }

    public bool HasPublicWinners { get; set; }

    public string PrizeDescription { get; set; }

    public string[] CountryCodes { get; set; }

    public int PremiumSubscriptionMonthCount { get; set; }
}
