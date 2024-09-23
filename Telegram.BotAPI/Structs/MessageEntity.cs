namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#messageentity
    public class MessageEntity
    {
        public string Type { get; set; }

        public int Offset { get; set; }

        public int Length { get; set; }

        public string Url { get; set; }

        public User User { get; set; }

        public string Language { get; set; }

        public string CustomEmojiId { get; set; }
    }
}
