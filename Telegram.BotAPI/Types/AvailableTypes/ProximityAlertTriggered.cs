namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes a service message sent when a user triggers a proximity alert set by another user.
/// </summary>
public sealed class ProximityAlertTriggered
{
    /// <summary>The user that triggered the alert.</summary>
    public required User Traveler { get; init; }

    /// <summary>The user that set the alert.</summary>
    public required User Watcher { get; init; }

    /// <summary>The distance between the users.</summary>
    public required int Distance { get; init; }
}
