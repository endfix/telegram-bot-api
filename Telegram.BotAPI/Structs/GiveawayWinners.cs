namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#giveawaywinners
    public class GiveawayWinners
    {
        public Chat Chat { get; set; }

        public int GiveawayMessageId { get; set; }

        public int WinnersSelectionDate { get; set; }

        public int WinnerCount { get; set; }

        public List<User> Winners { get; set; }

        public int AdditionalChatCount { get; set; }

        public int PremiumSubscriptionMonthCount { get; set; }

        public int UnclaimedPrizeCount { get; set; }

        public bool OnlyNewMembers { get; set; }

        public bool WasRefunded { get; set; }

        public string PrizeDescription { get; set; }
    }
}
