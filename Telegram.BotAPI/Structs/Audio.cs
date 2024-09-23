namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#audio
    public class Audio
    {
        public string FileId { get; set; }

        public string FileUniqueId { get; set; }

        public int Duration { get; set; }

        public string Performer { get; set; }

        public string Title { get; set; }

        public string FileName { get; set; }

        public string MimeType { get; set; }

        public int FileSize { get; set; }

        public PhotoSize Thumbnail { get; set; }
    }
}
