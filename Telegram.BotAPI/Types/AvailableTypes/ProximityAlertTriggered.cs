namespace Telegram.BotAPI.Types;

public sealed class ProximityAlertTriggered
{
    public required User Traveler { get; init; }

    public required User Watcher { get; init; }

    public required int Distance { get; init; }
}
