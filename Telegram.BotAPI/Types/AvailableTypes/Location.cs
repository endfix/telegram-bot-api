namespace Telegram.BotAPI.Types;

public sealed class Location
{
    public double Longitude { get; init; }

    public double Latitude { get; init; }

    public float? HorizontalAccuracy { get; init; }

    public int? LivePeriod { get; init; }

    public int? Heading { get; init; }

    public int? ProximityAlertRadius { get; init; }
}
