namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Represents a location to which a chat is connected.
/// </summary>
public sealed class ChatLocation
{
    /// <summary>
    /// The location to which the supergroup is connected. Cannot be a live location.
    /// </summary>
    public required Location Location { get; init; }

    /// <summary>
    /// Location address; 1-64 characters, as defined by the chat owner.
    /// </summary>
    public required string Address { get; init; }
}
