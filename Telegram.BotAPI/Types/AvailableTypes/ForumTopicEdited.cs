namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes a service message about an edited forum topic.</summary>
public sealed class ForumTopicEdited
{
    /// <summary>Optional. New name of the topic, if it was edited.</summary>
    public string? Name { get; init; }

    /// <summary>Optional. New custom emoji identifier; an empty string means that the icon was removed.</summary>
    public string? IconCustomEmojiId { get; init; }
}
