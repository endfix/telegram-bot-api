using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes the content of a story to be posted.
/// </summary>
public abstract class InputStoryContent
{
    /// <summary>Gets the type of the story content.</summary>
    public abstract InputStoryContentType Type { get; }
}

/// <summary>Represents a photo story.</summary>
public sealed class InputStoryContentPhoto : InputStoryContent
{
    /// <inheritdoc />
    public override InputStoryContentType Type => InputStoryContentType.Photo;

    /// <summary>The photo to post as a story.</summary>
    public required InputPhotoFile Photo { get; init; }
}

/// <summary>Represents a video story.</summary>
public sealed class InputStoryContentVideo : InputStoryContent
{
    /// <inheritdoc />
    public override InputStoryContentType Type => InputStoryContentType.Video;

    /// <summary>The video to post as a story.</summary>
    public required InputVideoFile Video { get; init; }

    /// <summary>Optional duration of the video in seconds.</summary>
    public float? Duration { get; init; }

    /// <summary>Optional timestamp in seconds of the video frame used as the cover.</summary>
    public float? CoverFrameTimestamp { get; init; }

    /// <summary>Optional pass true if the video is an animation.</summary>
    public bool? IsAnimation { get; init; }
}
