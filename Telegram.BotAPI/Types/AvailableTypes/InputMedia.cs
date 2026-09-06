using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Base type for media sent to Telegram.</summary>
public abstract class InputMedia
{
    /// <summary>Gets the media kind.</summary>
    public abstract InputMediaType Type { get; }
}

/// <summary>Base type for media whose content is supplied as a file or reusable media source.</summary>
public abstract class InputMediaFile : InputMedia
{
    /// <summary>Media source to send.</summary>
    public required virtual MediaSource Media { get; init; }
}

/// <summary>Base type for file media that can contain a caption.</summary>
public abstract class InputMediaCaptionedFile : InputMediaFile
{
    /// <summary>Media caption, if supplied.</summary>
    public virtual string? Caption { get; init; }

    /// <summary>Mode used to parse entities in the caption, if supplied.</summary>
    public virtual string? ParseMode { get; init; }

    /// <summary>Explicit entities in the caption, if supplied instead of a parse mode.</summary>
    public virtual IReadOnlyList<MessageEntity>? CaptionEntities { get; init; }
}

/// <summary>Describes an animation to send.</summary>
public sealed class InputMediaAnimation : InputMediaCaptionedFile, IInputPollMedia, IInputPollOptionMedia
{
    /// <summary>Gets the animation media kind.</summary>
    public override InputMediaType Type => InputMediaType.Animation;

    /// <summary>Animation thumbnail, if supplied.</summary>
    public ThumbnailSource? Thumbnail { get; init; }

    /// <summary>Indicates whether to show the caption above the animation.</summary>
    public bool? ShowCaptionAboveMedia { get; init; }

    public int? Width { get; init; }

    public int? Height { get; init; }

    public int? Duration { get; init; }

    /// <summary>Indicates whether the animation is covered by a spoiler animation.</summary>
    public bool? HasSpoiler { get; init; }
}

/// <summary>Describes a document to send.</summary>
public sealed class InputMediaDocument : InputMediaCaptionedFile, IInputPollMedia
{
    /// <summary>Gets the document media kind.</summary>
    public override InputMediaType Type => InputMediaType.Document;

    /// <summary>Document thumbnail, if supplied.</summary>
    public ThumbnailSource? Thumbnail { get; init; }

    /// <summary>Disables automatic content type detection when set.</summary>
    public bool? DisableContentTypeDetection { get; init; }
}

/// <summary>Describes an audio file to send.</summary>
public sealed class InputMediaAudio : InputMediaCaptionedFile, IInputPollMedia
{
    /// <summary>Gets the audio media kind.</summary>
    public override InputMediaType Type => InputMediaType.Audio;

    public ThumbnailSource? Thumbnail { get; init; }

    public int? Duration { get; init; }

    public string? Performer { get; init; }

    public string? Title { get; init; }
}

/// <summary>Describes an HTTP link to use as media.</summary>
public sealed class InputMediaLink : InputMedia, IInputPollOptionMedia
{
    /// <summary>Gets the link media kind.</summary>
    public override InputMediaType Type => InputMediaType.Link;

    /// <summary>HTTP link to the media.</summary>
    public required string Url { get; init; }
}

/// <summary>Describes a live photo to send.</summary>
public sealed class InputMediaLivePhoto : InputMediaCaptionedFile, IInputPollMedia, IInputPollOptionMedia
{
    /// <summary>Gets the live-photo media kind.</summary>
    public override InputMediaType Type => InputMediaType.LivePhoto;

    /// <summary>Photo media source.</summary>
    public required MediaSource Photo { get; init; }

    public bool? ShowCaptionAboveMedia { get; init; }

    public bool? HasSpoiler { get; init; }
}

/// <summary>Describes a location to send as media.</summary>
public sealed class InputMediaLocation : InputMedia, IInputPollMedia, IInputPollOptionMedia
{
    /// <summary>Gets the location media kind.</summary>
    public override InputMediaType Type => InputMediaType.Location;

    public required double Latitude { get; init; }

    public required double Longitude { get; init; }

    public double? HorizontalAccuracy { get; init; }
}

/// <summary>Describes a photo to send.</summary>
public sealed class InputMediaPhoto : InputMediaCaptionedFile, IInputPollMedia, IInputPollOptionMedia
{
    /// <summary>Gets the photo media kind.</summary>
    public override InputMediaType Type => InputMediaType.Photo;

    public bool? ShowCaptionAboveMedia { get; init; }

    public bool? HasSpoiler { get; init; }
}

/// <summary>Describes a sticker to send.</summary>
public sealed class InputMediaSticker : InputMediaFile, IInputPollOptionMedia
{
    /// <summary>Gets the sticker media kind.</summary>
    public override InputMediaType Type => InputMediaType.Sticker;

    /// <summary>Emoji associated with the sticker, if supplied.</summary>
    public string? Emoji { get; init; }
}

/// <summary>Describes a venue to send as media.</summary>
public sealed class InputMediaVenue : InputMedia, IInputPollMedia, IInputPollOptionMedia
{
    /// <summary>Gets the venue media kind.</summary>
    public override InputMediaType Type => InputMediaType.Venue;

    public required double Latitude { get; init; }

    public required double Longitude { get; init; }

    public required string Title { get; init; }

    public required string Address { get; init; }

    public string? FoursquareId { get; init; }

    public string? FoursquareType { get; init; }

    public string? GooglePlaceId { get; init; }

    public string? GooglePlaceType { get; init; }
}

/// <summary>Describes a video to send.</summary>
public sealed class InputMediaVideo : InputMediaCaptionedFile, IInputPollMedia, IInputPollOptionMedia
{
    /// <summary>Gets the video media kind.</summary>
    public override InputMediaType Type => InputMediaType.Video;

    /// <summary>Video thumbnail, if supplied.</summary>
    public ThumbnailSource? Thumbnail { get; init; }

    /// <summary>Video cover, if supplied.</summary>
    public CoverSource? Cover { get; init; }

    public int? StartTimestamp { get; init; }

    /// <summary>Indicates whether to show the caption above the video.</summary>
    public bool? ShowCaptionAboveMedia { get; init; }

    public int? Width { get; init; }

    public int? Height { get; init; }

    public int? Duration { get; init; }

    /// <summary>Indicates whether the video supports streaming.</summary>
    public bool? SupportsStreaming { get; init; }

    public bool? HasSpoiler { get; init; }
}

/// <summary>Describes a voice note to send.</summary>
public sealed class InputMediaVoiceNote : InputMediaFile
{
    /// <summary>Gets the voice-note media kind.</summary>
    public override InputMediaType Type =>  InputMediaType.VoiceNote;

    /// <summary>Duration of the voice note in seconds, if supplied.</summary>
    public int? Duration { get; init; }
}
