using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes a shipping option.</summary>
public sealed class ShippingOption
{
    /// <summary>Shipping option identifier.</summary>
    public required string Id { get; init; }

    /// <summary>Shipping option title.</summary>
    public required string Title { get; init; }

    /// <summary>List of price portions for this shipping option.</summary>
    public required IReadOnlyList<LabeledPrice> Prices { get; init; }
}
