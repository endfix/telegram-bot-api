namespace Telegram.BotAPI.Structs
{
    public class Voice
    {
        public string FileId { get; set; }

        public string FileUniqueId { get; set; }

        public int Duration { get; set; }

        public string MimeType { get; set; }

        public int FileSize { get; set; }
    }
}
