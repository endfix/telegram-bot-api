namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes an update about a user stopping message generation.
/// </summary>
public sealed class MessageGenerationStopped
{
    /// <summary>Chat in which the message was generated.</summary>
    public required Chat Chat { get; init; }

    /// <summary>Optional identifier of the message thread in which the message was generated.</summary>
    public long? MessageThreadId { get; init; }

    /// <summary>Unique identifier of the message draft that was stopped.</summary>
    public required long DraftId { get; init; }
}
