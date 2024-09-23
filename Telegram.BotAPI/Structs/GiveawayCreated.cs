namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#giveawaycreated
    public class GiveawayCreated
    {
        public List<Chat> Chats { get; set; }

        public int WinnersSelectionDate { get; set; }

        public int WinnerCount { get; set; }

        public bool OnlyNewMembers { get; set; }

        public bool HasPublicWinners { get; set; }

        public string PrizeDescription { get; set; }

        public List<string> CountryCodes { get; set; }
    }
}
