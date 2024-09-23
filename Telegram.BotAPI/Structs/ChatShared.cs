namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#chatshared
    public class ChatShared
    {
        public int RequestId { get; set; }

        public long ChatId { get; set; }

        public string Title { get; set; }

        public string Username { get; set; }

        public List<PhotoSize> Photo { get; set; }
    }
}
