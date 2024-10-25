namespace Telegram.BotAPI.Types.Payments;

// https://core.telegram.org/bots/api#orderinfo
public sealed class OrderInfo
{
    public string Name { get; set; }

    public string PhoneNumber { get; set; }

    public string Email { get; set; }

    public ShippingAddress ShippingAddress { get; set; }
}
