namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes a clickable area on a story media.
/// </summary>
public sealed class StoryArea
{
    /// <summary>
    /// The position of the area.
    /// </summary>
    public required StoryAreaPosition Position { get; init; }

    /// <summary>
    /// The type of the area.
    /// </summary>
    public required StoryAreaType Type { get; init; }
}
