namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#orderinfo
    public class OrderInfo
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public ShippingAddress ShippingAddress { get; set; }
    }
}
