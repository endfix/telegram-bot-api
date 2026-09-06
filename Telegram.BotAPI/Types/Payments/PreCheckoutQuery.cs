namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents an incoming pre-checkout query.</summary>
public sealed class PreCheckoutQuery
{
    /// <summary>Unique identifier for this query.</summary>
    public required string Id { get; init; }

    /// <summary>Sender of the query.</summary>
    public required User From { get; init; }

    /// <summary>Three-letter ISO 4217 currency code.</summary>
    public required string Currency { get; init; }

    /// <summary>Total price in the smallest units of the currency, such as cents or kopeks.</summary>
    public required int TotalAmount { get; init; }

    /// <summary>Bot-defined invoice payload.</summary>
    public required string InvoicePayload { get; init; }

    /// <summary>Identifier of the selected shipping option, if applicable.</summary>
    public string? ShippingOptionId { get; init; }

    /// <summary>Order information provided by the user, if available.</summary>
    public OrderInfo? OrderInfo { get; init; }
}
