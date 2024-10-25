namespace Telegram.BotAPI.Types
{
    // https://core.telegram.org/bots/api#photosize
    public sealed class PhotoSize
    {
        public string FileId { get; set; }

        public string FileUniqueId { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int FileSize { get; set; }
    }
}
