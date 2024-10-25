namespace Telegram.BotAPI.Types.Payments;

// https://core.telegram.org/bots/api#refundedpayment
public sealed class RefundedPayment
{
    public string Currency { get; set; }

    public int TotalAmount { get; set; }

    public string InvoicePayload { get; set; }

    public string TelegramPaymentChargeId { get; set; }

    public string ProviderPaymentChargeId { get; set; }
}
