namespace Telegram.BotAPI.Types;

public sealed class ProximityAlertTriggered
{
    public User Traveler { get; set; }

    public User Watcher { get; set; }

    public int Distance { get; set; }
}
