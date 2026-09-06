namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Contains information about a refunded payment.</summary>
public sealed class RefundedPayment
{
    /// <summary>Three-letter ISO 4217 currency code.</summary>
    public required string Currency { get; init; }

    /// <summary>Total refunded price in the smallest units of the currency.</summary>
    public required int TotalAmount { get; init; }

    /// <summary>Bot-specified invoice payload.</summary>
    public required string InvoicePayload { get; init; }

    /// <summary>Telegram payment identifier.</summary>
    public required string TelegramPaymentChargeId { get; init; }

    /// <summary>Provider payment identifier, if available.</summary>
    public string? ProviderPaymentChargeId { get; init; }
}
