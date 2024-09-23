namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#passportfile
    public class PassportFile
    {
        public string FileId { get; set; }

        public string FileUniqueId { get; set; }

        public int FileSize { get; set; }

        public int FileDate { get; set; }
    }
}
