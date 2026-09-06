namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents a shipping address.</summary>
public sealed class ShippingAddress
{
    /// <summary>Two-letter ISO 3166-1 alpha-2 country code.</summary>
    public required string CountryCode { get; init; }

    /// <summary>State, if applicable.</summary>
    public required string State { get; init; }

    /// <summary>City.</summary>
    public required string City { get; init; }

    /// <summary>First line of the street address.</summary>
    public required string StreetLine1 { get; init; }

    /// <summary>Second line of the street address, if applicable.</summary>
    public required string StreetLine2 { get; init; }

    /// <summary>Post code.</summary>
    public required string PostCode { get; init; }
}
