namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#proximityalerttriggered
    public class ProximityAlertTriggered
    {
        public User Traveler { get; set; }

        public User Watcher { get; set; }

        public int Distance { get; set; }
    }
}
