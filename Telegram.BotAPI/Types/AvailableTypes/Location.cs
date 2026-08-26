namespace Endfix.Telegram.BotAPI.Types;

public sealed class Location
{
    public required double Longitude { get; init; }

    public required double Latitude { get; init; }

    public float? HorizontalAccuracy { get; init; }

    public int? LivePeriod { get; init; }

    public int? Heading { get; init; }

    public int? ProximityAlertRadius { get; init; }
}
