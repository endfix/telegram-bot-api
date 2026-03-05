namespace Telegram.BotAPI.Types;

public sealed class ShippingQuery
{
    public required string Id { get; init; }

    public required User From { get; init; }

    public required string InvoicePayload { get; init; }

    public required ShippingAddress ShippingAddress { get; init; }
}
