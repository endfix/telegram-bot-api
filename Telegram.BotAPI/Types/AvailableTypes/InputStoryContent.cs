using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

public abstract class InputStoryContent
{
    public abstract InputStoryContentType Type { get; }
}

public sealed class InputStoryContentPhoto : InputStoryContent
{
    public override InputStoryContentType Type => InputStoryContentType.Photo;

    public required string Photo { get; init; }
}

public sealed class InputStoryContentVideo : InputStoryContent
{
    public override InputStoryContentType Type => InputStoryContentType.Video;

    public required string Video { get; init; }

    public float? Duration { get; init; }

    public float? CoverFrameTimestamp { get; init; }

    public bool? IsAnimation { get; init; }
}