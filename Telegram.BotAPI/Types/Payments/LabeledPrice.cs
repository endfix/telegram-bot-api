namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes a portion of the price for goods or services.</summary>
public sealed class LabeledPrice
{
    /// <summary>Portion label.</summary>
    public required string Label { get; init; }

    /// <summary>Price of the portion in the smallest units of the currency.</summary>
    public required int Amount { get; init; }
}
