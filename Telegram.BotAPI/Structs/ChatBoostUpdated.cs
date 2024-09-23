namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#chatboostupdated
    public class ChatBoostUpdated
    {
        public Chat Chat { get; set; }

        public ChatBoost Boost { get; set; }
    }
}
