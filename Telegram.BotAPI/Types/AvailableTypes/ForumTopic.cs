namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents a forum topic.</summary>
public sealed class ForumTopic
{
    /// <summary>Unique identifier of the forum topic.</summary>
    public required long MessageThreadId { get; init; }

    /// <summary>Name of the topic.</summary>
    public required string Name { get; init; }

    /// <summary>Color of the topic icon in RGB format.</summary>
    public required int IconColor { get; init; }

    /// <summary>Optional. Unique identifier of the custom emoji shown as the topic icon.</summary>
    public string? IconCustomEmojiId { get; init; }

    /// <summary>Optional. Indicates that the topic name was not specified explicitly by its creator.</summary>
    public bool? IsNameImplicit { get; init; }
}
