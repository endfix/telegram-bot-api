namespace Telegram.BotAPI.Types;

public sealed class ShippingQuery
{
    public string Id { get; set; }

    public User From { get; set; }

    public string InvoicePayload { get; set; }

    public ShippingAddress ShippingAddress { get; set; }
}
