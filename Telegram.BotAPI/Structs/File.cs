namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#file
    public class File
    {
        public string FileId { get; set; }

        public string FileUniqueId { get; set; }

        public int FileSize { get; set; }

        public string FilePath { get; set; }
    }
}
