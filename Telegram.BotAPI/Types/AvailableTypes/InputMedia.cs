using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

public abstract class InputMedia
{
    public abstract InputMediaType Type { get; }
}

public abstract class InputMediaFile : InputMedia
{
    public required virtual MediaSource Media { get; init; }
}

public abstract class InputMediaCaptionedFile : InputMediaFile
{
    public virtual string? Caption { get; init; }

    public virtual string? ParseMode { get; init; }

    public virtual IReadOnlyList<MessageEntity>? CaptionEntities { get; init; }
}

public sealed class InputMediaAnimation : InputMediaCaptionedFile, IInputPollMedia, IInputPollOptionMedia
{
    public override InputMediaType Type => InputMediaType.Animation;

    public ThumbnailSource? Thumbnail { get; init; }

    public bool? ShowCaptionAboveMedia { get; init; }

    public int? Width { get; init; }

    public int? Height { get; init; }

    public int? Duration { get; init; }

    public bool? HasSpoiler { get; init; }
}

public sealed class InputMediaDocument : InputMediaCaptionedFile, IInputPollMedia
{
    public override InputMediaType Type => InputMediaType.Document;

    public ThumbnailSource? Thumbnail { get; init; }

    public bool? DisableContentTypeDetection { get; init; }
}

public sealed class InputMediaAudio : InputMediaCaptionedFile, IInputPollMedia
{
    public override InputMediaType Type => InputMediaType.Audio;

    public ThumbnailSource? Thumbnail { get; init; }

    public int? Duration { get; init; }

    public string? Performer { get; init; }

    public string? Title { get; init; }
}

public sealed class InputMediaLink : InputMedia, IInputPollOptionMedia
{
    public override InputMediaType Type => InputMediaType.Link;

    public required string Url { get; init; }
}

public sealed class InputMediaLivePhoto : InputMediaCaptionedFile, IInputPollMedia, IInputPollOptionMedia
{
    public override InputMediaType Type => InputMediaType.LivePhoto;

    public required MediaSource Photo { get; init; }

    public bool? ShowCaptionAboveMedia { get; init; }

    public bool? HasSpoiler { get; init; }
}

public sealed class InputMediaLocation : InputMedia, IInputPollMedia, IInputPollOptionMedia
{
    public override InputMediaType Type => InputMediaType.Location;

    public required double Latitude { get; init; }

    public required double Longitude { get; init; }

    public double? HorizontalAccuracy { get; init; }
}

public sealed class InputMediaPhoto : InputMediaCaptionedFile, IInputPollMedia, IInputPollOptionMedia
{
    public override InputMediaType Type => InputMediaType.Photo;

    public bool? ShowCaptionAboveMedia { get; init; }

    public bool? HasSpoiler { get; init; }
}

public sealed class InputMediaSticker : InputMediaFile, IInputPollOptionMedia
{
    public override InputMediaType Type => InputMediaType.Sticker;

    public string? Emoji { get; init; }
}

public sealed class InputMediaVenue : InputMedia, IInputPollMedia, IInputPollOptionMedia
{
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

public sealed class InputMediaVideo : InputMediaCaptionedFile, IInputPollMedia, IInputPollOptionMedia
{
    public override InputMediaType Type => InputMediaType.Video;

    public ThumbnailSource? Thumbnail { get; init; }

    public CoverSource? Cover { get; init; }

    public int? StartTimestamp { get; init; }

    public bool? ShowCaptionAboveMedia { get; init; }

    public int? Width { get; init; }

    public int? Height { get; init; }

    public int? Duration { get; init; }

    public bool? SupportsStreaming { get; init; }

    public bool? HasSpoiler { get; init; }
}

public sealed class InputMediaVoiceNote : InputMediaFile
{
    public override InputMediaType Type =>  InputMediaType.VoiceNote;

    public int? Duration { get; init; }
}
