namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#businessopeninghoursinterval
    public class BusinessOpeningHoursInterval
    {
        public int OpeningMinute { get; set; }

        public int ClosingMinute { get; set; }
    }
}
