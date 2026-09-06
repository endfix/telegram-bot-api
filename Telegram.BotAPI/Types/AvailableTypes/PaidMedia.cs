using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Base type for media available after a payment.</summary>
public abstract class PaidMedia
{
    /// <summary>Gets the paid media kind.</summary>
    public abstract PaidMediaType Type { get; }
}

/// <summary>Represents paid media containing a live photo.</summary>
public sealed class PaidMediaLivePhoto : PaidMedia
{
    /// <summary>Gets the live-photo media kind.</summary>
    public override PaidMediaType Type => PaidMediaType.LivePhoto;

    /// <summary>Live photo.</summary>
    public required LivePhoto LivePhoto { get; init; }
}

/// <summary>Represents paid media containing a photo.</summary>
public sealed class PaidMediaPhoto : PaidMedia
{
    /// <summary>Gets the photo media kind.</summary>
    public override PaidMediaType Type => PaidMediaType.Photo;

    /// <summary>Available sizes of the photo.</summary>
    public required IReadOnlyList<PhotoSize> Photo { get; init; }
}

/// <summary>Represents paid media that is not available before payment.</summary>
public sealed class PaidMediaPreview : PaidMedia
{
    /// <summary>Gets the preview media kind.</summary>
    public override PaidMediaType Type => PaidMediaType.Preview;

    /// <summary>Media width, if available.</summary>
    public int? Width { get; init; }

    /// <summary>Media height, if available.</summary>
    public int? Height { get; init; }

    /// <summary>Media duration in seconds, if available.</summary>
    public int? Duration { get; init; }
}

/// <summary>Represents paid media containing a video.</summary>
public sealed class PaidMediaVideo : PaidMedia
{
    /// <summary>Gets the video media kind.</summary>
    public override PaidMediaType Type => PaidMediaType.Video;

    /// <summary>Video.</summary>
    public required Video Video { get; init; }
}
