using System.Collections.Generic;
using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public abstract class InputMedia
{
    public abstract InputMediaTypes Type { get; }

    public required virtual MediaSource Media { get; init; }

    public virtual string? Caption { get; init; }

    public virtual string? ParseMode { get; init; }

    public virtual IReadOnlyList<MessageEntity>? CaptionEntities { get; init; }
}

public sealed class InputMediaAnimation : InputMedia
{
    public override InputMediaTypes Type => InputMediaTypes.Animation;

    public object? Thumbnail { get; init; }

    public bool? ShowCaptionAboveMedia { get; init; }

    public int? Width { get; init; }

    public int? Height { get; init; }

    public int? Duration { get; init; }

    public bool? HasSpoiler { get; init; }
}

public sealed class InputMediaDocument : InputMedia
{
    public override InputMediaTypes Type => InputMediaTypes.Document;

    public object? Thumbnail { get; init; }

    public bool? DisableContentTypeDetection { get; init; }
}

public sealed class InputMediaAudio : InputMedia
{
    public override InputMediaTypes Type => InputMediaTypes.Audio;

    public object? Thumbnail { get; init; }

    public int? Duration { get; init; }

    public string? Performer { get; init; }

    public string? Title { get; init; }
}

public sealed class InputMediaPhoto : InputMedia
{
    public override InputMediaTypes Type => InputMediaTypes.Photo;

    public bool? ShowCaptionAboveMedia { get; init; }

    public bool? HasSpoiler { get; init; }
}

public sealed class InputMediaVideo : InputMedia
{
    public override InputMediaTypes Type => InputMediaTypes.Video;

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
