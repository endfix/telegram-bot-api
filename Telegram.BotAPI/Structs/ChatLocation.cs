namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#chatlocation
    public class ChatLocation
    {
        public Location Location { get; set; }

        public string Address { get; set; }
    }
}
