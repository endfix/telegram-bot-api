using System.Collections.Generic;

namespace Telegram.BotAPI.Types.Payments;

/// <summary>
/// This object represents one shipping option.
/// </summary>
public sealed class ShippingOption
{
    /// <summary>
    /// Shipping option identifier
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Option title
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// List of price portions
    /// </summary>
    public List<LabeledPrice> Prices { get; set; }
}
