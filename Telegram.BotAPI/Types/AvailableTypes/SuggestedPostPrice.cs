namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes the price associated with a suggested post.</summary>
public sealed class SuggestedPostPrice
{
    /// <summary>Three-letter ISO 4217 currency code.</summary>
    public required string Currency { get; init; }

    /// <summary>Amount in the smallest units of the currency.</summary>
    public required int Amount { get; init; }
}
