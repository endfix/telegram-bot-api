using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Base type for paid media to be sent.</summary>
public abstract class InputPaidMedia
{
    /// <summary>Gets the paid media type.</summary>
    public abstract InputPaidMediaType Type { get; }

    /// <summary>Media file to send.</summary>
    public required virtual MediaSource Media { get; init; }
}

/// <summary>Describes a live photo to send as paid media.</summary>
public sealed class InputPaidMediaLivePhoto : InputPaidMedia
{
    /// <inheritdoc/>
    public override InputPaidMediaType Type => InputPaidMediaType.LivePhoto;

    /// <summary>Static photo of the live photo.</summary>
    public required MediaSource Photo { get; init; }
}

/// <summary>Describes a photo to send as paid media.</summary>
public sealed class InputPaidMediaPhoto : InputPaidMedia
{
    /// <inheritdoc/>
    public override InputPaidMediaType Type => InputPaidMediaType.Photo;
}

/// <summary>Describes a video to send as paid media.</summary>
public sealed class InputPaidMediaVideo : InputPaidMedia
{
    /// <inheritdoc/>
    public override InputPaidMediaType Type => InputPaidMediaType.Video;

    /// <summary>Optional. Thumbnail of the video.</summary>
    public ThumbnailSource? Thumbnail { get; init; }

    /// <summary>Optional. Cover image of the video.</summary>
    public CoverSource? Cover { get; init; }

    /// <summary>Optional. Start timestamp of the video preview, in seconds.</summary>
    public int? StartTimestamp { get; init; }

    /// <summary>Optional. Video width.</summary>
    public int? Width { get; init; }

    /// <summary>Optional. Video height.</summary>
    public int? Height { get; init; }

    /// <summary>Optional. Video duration in seconds.</summary>
    public int? Duration { get; init; }

    /// <summary>Optional. Indicates whether the video supports streaming.</summary>
    public bool? SupportsStreaming { get; init; }
}
