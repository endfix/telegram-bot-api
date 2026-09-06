namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes an invoice for a payment.</summary>
public sealed class Invoice
{
    /// <summary>Product name.</summary>
    public required string Title { get; init; }

    /// <summary>Product description.</summary>
    public required string Description { get; init; }

    /// <summary>Unique bot deep-linking parameter that can be used to generate a payment invoice.</summary>
    public required string StartParameter { get; init; }

    /// <summary>Three-letter ISO 4217 currency code.</summary>
    public required string Currency { get; init; }

    /// <summary>Total price in the smallest units of the currency.</summary>
    public required int TotalAmount { get; init; }
}
