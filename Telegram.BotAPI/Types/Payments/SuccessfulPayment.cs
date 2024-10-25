namespace Telegram.BotAPI.Types.Payments;

// https://core.telegram.org/bots/api#successfulpayment
public sealed class SuccessfulPayment
{
    public string Currency { get; set; }

    public int TotalAmount { get; set; }

    public string InvoicePayload { get; set; }

    public string ShippingOptionId { get; set; }

    public OrderInfo OrderInfo { get; set; }

    public string TelegramPaymentChargeId { get; set; }

    public string ProviderPaymentChargeId { get; set; }
}
