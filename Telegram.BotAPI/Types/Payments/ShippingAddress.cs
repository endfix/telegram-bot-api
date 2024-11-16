namespace Telegram.BotAPI.Types.Payments;

/// <summary>
/// This object represents a shipping address.
/// </summary>
public sealed class ShippingAddress
{
    /// <summary>
    /// Two-letter <see href="https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2">ISO 3166-1 alpha-2</see> country code
    /// </summary>
    public string CountryCode { get; set; }

    /// <summary>
    /// State, if applicable
    /// </summary>
    public string State { get; set; }

    /// <summary>
    /// City
    /// </summary>
    public string City { get; set; }

    /// <summary>
    /// First line for the address
    /// </summary>
    public string StreetLine1 { get; set; }

    /// <summary>
    /// Second line for the address
    /// </summary>
    public string StreetLine2 { get; set; }

    /// <summary>
    /// Address post code
    /// </summary>
    public string PostCode { get; set; }
}
