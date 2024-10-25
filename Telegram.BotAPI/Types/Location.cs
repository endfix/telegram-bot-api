namespace Telegram.BotAPI.Types
{
    // https://core.telegram.org/bots/api#location
    public class Location
    {
        public float Longitude { get; set; }

        public float Latitude { get; set; }

        public float HorizontalAccuracy { get; set; }

        public int LivePeriod { get; set; }

        public int Heading { get; set; }

        public int ProximityAlertRadius { get; set; }
    }
}
