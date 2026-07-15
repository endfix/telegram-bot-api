using System.Collections.Generic;
using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public abstract class InputMedia
{
    public abstract InputMediaType Type { get; }

    public required virtual MediaSource Media { get; init; }

    public virtual string? Caption { get; init; }

    public virtual string? ParseMode { get; init; }

    public virtual IReadOnlyList<MessageEntity>? CaptionEntities { get; init; }
}

public sealed class InputMediaAnimation : InputMedia
{
    public override InputMediaType Type => InputMediaType.Animation;

    public object? Thumbnail { get; init; }

    public bool? ShowCaptionAboveMedia { get; init; }

    public int? Width { get; init; }

    public int? Height { get; init; }

    public int? Duration { get; init; }

    public bool? HasSpoiler { get; init; }
}

public sealed class InputMediaDocument : InputMedia
{
    public override InputMediaType Type => InputMediaType.Document;

    public object? Thumbnail { get; init; }

    public bool? DisableContentTypeDetection { get; init; }
}

public sealed class InputMediaAudio : InputMedia
{
    public override InputMediaType Type => InputMediaType.Audio;

    public object? Thumbnail { get; init; }

    public int? Duration { get; init; }

    public string? Performer { get; init; }

    public string? Title { get; init; }
}

public sealed class InputMediaLink : InputMedia
{
    public override InputMediaType Type => InputMediaType.Link;

    public required string Url { get; init; }
}

public sealed class InputMediaLivePhoto : InputMedia
{
    public override InputMediaType Type => InputMediaType.LivePhoto;

    public required MediaSource Photo { get; init; }

    public bool? ShowCaptionAboveMedia { get; init; }

    public bool? HasSpoiler { get; init; }
}

public sealed class InputMediaLocation : InputMedia
{
    public override InputMediaType Type => InputMediaType.Location;

    public required double Latitude { get; init; }

    public required double Longitude { get; init; }

    public double? HorizontalAccuracy { get; init; }
}

public sealed class InputMediaPhoto : InputMedia
{
    public override InputMediaType Type => InputMediaType.Photo;

    public bool? ShowCaptionAboveMedia { get; init; }

    public bool? HasSpoiler { get; init; }
}

public sealed class InputMediaSticker : InputMedia
{
    public override InputMediaType Type => InputMediaType.Sticker;

    public string? Emoji { get; init; }
}

public sealed class InputMediaVenue : InputMedia
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

public sealed class InputMediaVideo : InputMedia
{
    public override InputMediaType Type => InputMediaType.Video;

    public object? Thumbnail { get; init; }

    public string? Cover { get; init; }

    public int? StartTimestamp { get; init; }

    public bool? ShowCaptionAboveMedia { get; init; }

    public int? Width { get; init; }

    public int? Height { get; init; }

    public int? Duration { get; init; }

    public bool? SupportsStreaming { get; init; }

    public bool? HasSpoiler { get; init; }
}

public sealed class InputMediaVoiceNote : InputMedia
{
    public override InputMediaType Type =>  InputMediaType.VoiceNote;

    public int? Duration { get; init; }
}
