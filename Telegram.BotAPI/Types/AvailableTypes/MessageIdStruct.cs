namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Represents a unique message identifier.
/// </summary>
public sealed class MessageIdStruct
{
    /// <summary>Unique message identifier.</summary>
    public required long MessageId { get; init; }
}
