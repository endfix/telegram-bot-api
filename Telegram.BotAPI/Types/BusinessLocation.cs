namespace Telegram.BotAPI.Types;

// https://core.telegram.org/bots/api#businesslocation
public sealed class BusinessLocation
{
    public string Address { get; set; }

    public Location Location { get; set; }
}
