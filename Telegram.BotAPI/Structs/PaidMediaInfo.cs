namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#paidmediainfo
    public class PaidMediaInfo
    {
        public int StarCount { get; set; }

        public List<PaidMedia> PaidMedia { get; set; }
    }
}
