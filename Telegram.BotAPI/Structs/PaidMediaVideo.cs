namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#paidmediavideo
    public class PaidMediaVideo : PaidMedia
    {
        public string Type { get; set; } = "video";

        public Video Video { get; set; }
    }
}
