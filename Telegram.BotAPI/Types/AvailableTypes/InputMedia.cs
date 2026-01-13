using System.Collections.Generic;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(InputMediaAnimation), "animation")]
[JsonDerivedType(typeof(InputMediaDocument), "document")]
[JsonDerivedType(typeof(InputMediaAudio), "audio")]
[JsonDerivedType(typeof(InputMediaPhoto), "photo")]
[JsonDerivedType(typeof(InputMediaVideo), "video")]
public abstract class InputMedia
{
    [JsonIgnore]
    public abstract InputMediaTypes Type { get; }

    public required virtual string Media { get; init; }

    public virtual string? Caption { get; init; }

    public virtual string? ParseMode { get; init; }

    public virtual IReadOnlyList<MessageEntity>? CaptionEntities { get; init; }
}

public sealed class InputMediaAnimation : InputMedia
{
    public override InputMediaTypes Type => InputMediaTypes.Animation;

    public string? Thumbnail { get; init; }

    public bool? ShowCaptionAboveMedia { get; init; }

    public int? Width { get; init; }

    public int? Height { get; init; }

    public int? Duration { get; init; }

    public bool? HasSpoiler { get; init; }
}

public sealed class InputMediaDocument : InputMedia
{
    public override InputMediaTypes Type => InputMediaTypes.Document;

    public string? Thumbnail { get; init; }

    public bool? DisableContentTypeDetection { get; init; }
}

public sealed class InputMediaAudio : InputMedia
{
    public override InputMediaTypes Type => InputMediaTypes.Audio;

    public string? Thumbnail { get; init; }

    public int Duration { get; init; }

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

    public string? Thumbnail { get; init; }

    public string? Cover { get; init; }

    public int? StartTimestamp { get; init; }

    public bool? ShowCaptionAboveMedia { get; init; }

    public int? Width { get; init; }

    public int? Height { get; init; }

    public int? Duration { get; init; }

    public bool? SupportsStreaming { get; init; }

    public bool? HasSpoiler { get; init; }
}
