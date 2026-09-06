namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes the physical address of a location.
/// </summary>
public sealed class LocationAddress
{
    /// <summary>
    /// The two-letter ISO 3166-1 alpha-2 country code of the country where the location is located.
    /// </summary>
    public required string CountryCode { get; init; }

    /// <summary>Optional state of the location.</summary>
    public string? State { get; init; }

    /// <summary>Optional city of the location.</summary>
    public string? City { get; init; }

    /// <summary>Optional street address of the location.</summary>
    public string? Street { get; init; }
}
