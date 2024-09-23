namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#callbackquery
    public class CallbackQuery
    {
        public string Id { get; set; }

        public User From { get; set; }

        public Message Message { get; set; }

        public string InlineMessageId { get; set; }

        public string ChatInstance { get; set; }

        public string Data { get; set; }

        public string GameShortName { get; set; }
    }
}
