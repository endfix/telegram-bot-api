namespace Telegram.BotAPI.Types;

public sealed class PreCheckoutQuery
{
    public string Id { get; set; }

    public User From { get; set; }

    public string Currency { get; set; }

    public int TotalAmount { get; set; }

    public string InvoicePayload { get; set; }

    public string ShippingOptionId { get; set; }

    public OrderInfo OrderInfo { get; set; }
}
