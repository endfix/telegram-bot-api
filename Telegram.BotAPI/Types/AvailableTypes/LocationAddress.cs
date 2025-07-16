namespace Telegram.BotAPI.Types;

public sealed class LocationAddress
{
    public string CountryCode { get; set; }

    public string State { get; set; }

    public string City { get; set; }

    public string Street { get; set; }
}
