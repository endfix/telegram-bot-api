namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents a point on the map.</summary>
public sealed class Location
{
    /// <summary>Longitude as defined by the sender.</summary>
    public required double Longitude { get; init; }

    /// <summary>Latitude as defined by the sender.</summary>
    public required double Latitude { get; init; }

    /// <summary>Optional radius of uncertainty for the location, in meters.</summary>
    public float? HorizontalAccuracy { get; init; }

    /// <summary>Time relative to the message date during which the location can be updated, in seconds.</summary>
    public int? LivePeriod { get; init; }

    /// <summary>Direction in which the user is moving, in degrees, if available.</summary>
    public int? Heading { get; init; }

    /// <summary>Maximum distance for proximity alerts about approaching another chat member, in meters.</summary>
    public int? ProximityAlertRadius { get; init; }
}
