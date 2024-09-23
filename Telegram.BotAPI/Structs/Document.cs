namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#document
    public class Document
    {
        public string FileId { get; set; }

        public string FileUniqueId { get; set; }

        public PhotoSize Thumbnail { get; set; }

        public string FileName { get; set; }

        public string MimeType { get; set; }

        public int FileSize { get; set; }
    }
}
