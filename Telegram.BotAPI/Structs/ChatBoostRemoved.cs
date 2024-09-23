namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#chatboostremoved
    public class ChatBoostRemoved
    {
        public Chat Chat { get; set; }

        public string BoostId { get; set; }

        public int RemoveDate { get; set; }

        public ChatBoostSource Source { get; set; }
    }
}
