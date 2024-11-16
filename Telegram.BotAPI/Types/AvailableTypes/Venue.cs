namespace Telegram.BotAPI.Types.AvailableTypes;

public sealed class Venue
{
    public Location Location { get; set; }

    public string Title { get; set; }

    public string Address { get; set; }

    public string FoursquareId { get; set; }

    public string FoursquareType { get; set; }

    public string GooglePlaceId { get; set; }

    public string GooglePlaceType { get; set; }
}
