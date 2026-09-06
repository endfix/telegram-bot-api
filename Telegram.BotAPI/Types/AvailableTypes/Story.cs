namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Represents a story.
/// </summary>
public sealed class Story
{
    /// <summary>
    /// The chat that posted the story.
    /// </summary>
    public required Chat Chat { get; init; }

    /// <summary>
    /// The unique identifier of the story.
    /// </summary>
    public required long Id { get; init; }
}
