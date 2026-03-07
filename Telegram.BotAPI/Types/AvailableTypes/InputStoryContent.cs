using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public abstract class InputStoryContent
{
    public abstract InputStoryContentTypes Type { get; }
}

public sealed class InputStoryContentPhoto : InputStoryContent
{
    public override InputStoryContentTypes Type => InputStoryContentTypes.Photo;

    public required string Photo { get; init; }
}

public sealed class InputStoryContentVideo : InputStoryContent
{
    public override InputStoryContentTypes Type => InputStoryContentTypes.Video;

    public required string Video { get; init; }

    public float? Duration { get; init; }

    public float? CoverFrameTimestamp { get; init; }

    public bool? IsAnimation { get; init; }
}