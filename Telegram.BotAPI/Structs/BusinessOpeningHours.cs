namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#businessopeninghours
    public class BusinessOpeningHours
    {
        public string TimeZoneName { get; set; }

        public List<BusinessOpeningHoursInterval> OpeningHours { get; set; }
    }
}
