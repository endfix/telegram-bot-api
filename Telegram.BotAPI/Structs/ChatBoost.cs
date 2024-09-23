namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#chatboost
    public class ChatBoost
    {
        public string BoostId { get; set; }

        public int AddDate { get; set; }

        public int ExpirationDate { get; set; }

        public ChatBoostSource Source { get; set; }
    }
}
