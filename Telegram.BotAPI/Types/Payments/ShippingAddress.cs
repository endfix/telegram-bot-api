namespace Telegram.BotAPI.Types.Payments;

// https://core.telegram.org/bots/api#shippingaddress
public sealed class ShippingAddress
{
    public string CountryCode { get; set; }

    public string State { get; set; }

    public string City { get; set; }

    public string StreetLine1 { get; set; }

    public string StreetLine2 { get; set; }

    public string PostCode { get; set; }
}
