namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#callbackgame
    public class CallbackGame
    {
        public int UserId { get; set; }

        public int Score { get; set; }

        public bool Force { get; set; }

        public bool DisableEditMessage { get; set; }

        public int ChatId { get; set; }

        public int MessageId { get; set; }

        public string InlineMessageId { get; set; }
    }
}
