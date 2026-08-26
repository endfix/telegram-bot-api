namespace Endfix.Telegram.BotAPI.Types;

public sealed class RefundedPayment
{
    public required string Currency { get; init; }

    public required int TotalAmount { get; init; }

    public required string InvoicePayload { get; init; }

    public required string TelegramPaymentChargeId { get; init; }

    public string? ProviderPaymentChargeId { get; init; }
}
