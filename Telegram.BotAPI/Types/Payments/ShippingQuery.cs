using Telegram.BotAPI.Types.AvailableTypes;

namespace Telegram.BotAPI.Types.Payments;

/// <summary>
/// This object contains information about an incoming shipping query.
/// </summary>
public sealed class ShippingQuery
{
    /// <summary>
    /// Unique query identifier
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// User who sent the query
    /// </summary>
    public User From { get; set; }

    /// <summary>
    /// Bot-specified invoice payload
    /// </summary>
    public string InvoicePayload { get; set; }

    /// <summary>
    /// User specified shipping address
    /// </summary>
    public ShippingAddress ShippingAddress { get; set; }
}
