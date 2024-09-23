namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#paidmediaphoto
    public class PaidMediaPhoto : PaidMedia
    {
        public string Type { get; set; } = "photo";

        public List<PhotoSize> Photo { get; set; }
    }
}
