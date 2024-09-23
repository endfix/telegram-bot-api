namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#giveawaycompleted
    public class GiveawayCompleted
    {
        public int WinnerCount { get; set; }

        public int UnclaimedPrizeCount { get; set; }

        public Message GiveawayMessage { get; set; }
    }
}
