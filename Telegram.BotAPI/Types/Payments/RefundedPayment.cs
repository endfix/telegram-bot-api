namespace Telegram.BotAPI.Types;

public sealed class RefundedPayment
{
    public string Currency { get; set; }

    public int TotalAmount { get; set; }

    public string InvoicePayload { get; set; }

    public string TelegramPaymentChargeId { get; set; }

    public string ProviderPaymentChargeId { get; set; }
}
