namespace Endfix.Telegram.BotAPI.Types;

public sealed class SuccessfulPayment
{
    public required string Currency { get; init; }

    public required int TotalAmount { get; init; }

    public required string InvoicePayload { get; init; }

    public int? SubscriptionExpirationDate { get; init; }

    public bool? IsRecurring { get; init; }

    public bool? IsFirstRecurring { get; init; }

    public string? ShippingOptionId { get; init; }

    public OrderInfo? OrderInfo { get; init; }

    public required string TelegramPaymentChargeId { get; init; }

    public required string ProviderPaymentChargeId { get; init; }
}
