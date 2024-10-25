namespace Telegram.BotAPI.Types
{
    // https://core.telegram.org/bots/api#videonote
    public class VideoNote
    {
        public string FileId { get; set; }

        public string FileUniqueId { get; set; }

        public int Length { get; set; }

        public int Duration { get; set; }

        public PhotoSize Thumbnail { get; set; }

        public int FileSize { get; set; }
    }
}
