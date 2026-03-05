namespace Telegram.BotAPI.Types;

public sealed class PreCheckoutQuery
{
    public required string Id { get; init; }

    public required User From { get; init; }

    public required string Currency { get; init; }

    public required int TotalAmount { get; init; }

    public required string InvoicePayload { get; init; }

    public string? ShippingOptionId { get; init; }

    public OrderInfo? OrderInfo { get; init; }
}
