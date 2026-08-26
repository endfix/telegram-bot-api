namespace Endfix.Telegram.BotAPI.Types;

public sealed class StoryArea
{
    public required StoryAreaPosition Position { get; init; }

    public required StoryAreaType Type { get; init; }
}
