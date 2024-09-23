namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#businesslocation
    public class BusinessLocation
    {
        public string Address { get; set; }

        public Location Location { get; set; }
    }
}
