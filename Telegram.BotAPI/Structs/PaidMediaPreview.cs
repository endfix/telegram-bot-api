namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#paidmediapreview
    public class PaidMediaPreview : PaidMedia
    {
        public string Type { get; set; } = "preview";

        public int Width { get; set; }

        public int Height { get; set; }

        public int Duration { get; set; }
    }
}
