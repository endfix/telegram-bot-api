namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents a venue.</summary>
public sealed class Venue
{
    /// <summary>Venue location.</summary>
    public required Location Location { get; init; }

    /// <summary>Name of the venue.</summary>
    public required string Title { get; init; }

    /// <summary>Address of the venue.</summary>
    public required string Address { get; init; }

    /// <summary>Foursquare identifier of the venue, if available.</summary>
    public string? FoursquareId { get; init; }

    /// <summary>Foursquare type of the venue, if available.</summary>
    public string? FoursquareType { get; init; }

    /// <summary>Google Places identifier of the venue, if available.</summary>
    public string? GooglePlaceId { get; init; }

    /// <summary>Google Places type of the venue, if available.</summary>
    public string? GooglePlaceType { get; init; }
}
