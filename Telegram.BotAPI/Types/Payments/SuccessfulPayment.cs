namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Contains information about a successful payment.</summary>
public sealed class SuccessfulPayment
{
    /// <summary>Three-letter ISO 4217 currency code.</summary>
    public required string Currency { get; init; }

    /// <summary>Total price in the smallest units of the currency.</summary>
    public required int TotalAmount { get; init; }

    /// <summary>Bot-specified invoice payload.</summary>
    public required string InvoicePayload { get; init; }

    /// <summary>Expiration date of the subscription in Unix time, if applicable.</summary>
    public int? SubscriptionExpirationDate { get; init; }

    /// <summary>Indicates whether the payment is recurring, if applicable.</summary>
    public bool? IsRecurring { get; init; }

    /// <summary>Indicates whether this is the first recurring payment, if applicable.</summary>
    public bool? IsFirstRecurring { get; init; }

    /// <summary>Identifier of the chosen shipping option, if applicable.</summary>
    public string? ShippingOptionId { get; init; }

    /// <summary>Order information, if supplied.</summary>
    public OrderInfo? OrderInfo { get; init; }

    /// <summary>Telegram payment identifier.</summary>
    public required string TelegramPaymentChargeId { get; init; }

    /// <summary>Provider payment identifier.</summary>
    public required string ProviderPaymentChargeId { get; init; }
}
