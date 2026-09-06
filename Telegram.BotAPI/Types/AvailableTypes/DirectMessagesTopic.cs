namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes a topic of a direct messages chat.</summary>
public sealed class DirectMessagesTopic
{
    /// <summary>Unique identifier of the topic.</summary>
    public required long TopicId { get; init; }

    /// <summary>Optional. Information about the user who created the topic.</summary>
    public User? User { get; init; }
}
