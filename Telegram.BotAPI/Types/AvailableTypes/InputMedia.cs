using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public abstract class InputMedia
{
    public abstract InputMediaTypes Type { get; }

    public virtual string Media { get; set; }

    public virtual string Caption { get; set; }

    public virtual string ParseMode { get; set; }

    public virtual MessageEntity[] CaptionEntities { get; set; }
}

public sealed class InputMediaAnimation : InputMedia
{
    public override InputMediaTypes Type => InputMediaTypes.Animation;

    public string Thumbnail { get; set; } = string.Empty;

    public bool ShowCaptionAboveMedia { get; set; }

    public int Width { get; set; }

    public int Height { get; set; }

    public int Duration { get; set; }

    public bool HasSpoiler { get; set; }
}

public sealed class InputMediaDocument : InputMedia
{
    public override InputMediaTypes Type => InputMediaTypes.Document;

    public string Thumbnail { get; set; } = string.Empty;

    public bool DisableContentTypeDetection { get; set; }
}

public sealed class InputMediaAudio : InputMedia
{
    public override InputMediaTypes Type => InputMediaTypes.Audio;

    public string Thumbnail { get; set; } = string.Empty;

    public int Duration { get; set; }

    public string Performer { get; set; }

    public string Title { get; set; }
}

public sealed class InputMediaPhoto : InputMedia
{
    public override InputMediaTypes Type => InputMediaTypes.Photo;

    public bool ShowCaptionAboveMedia { get; set; }

    public bool HasSpoiler { get; set; }
}

public sealed class InputMediaVideo : InputMedia
{
    public override InputMediaTypes Type => InputMediaTypes.Video;

    public string Thumbnail { get; set; }

    public string Cover { get; set; }

    public int StartTimestamp { get; set; }

    public bool ShowCaptionAboveMedia { get; set; }

    public int Width { get; set; }

    public int Height { get; set; }

    public int Duration { get; set; }

    public bool SupportsStreaming { get; set; }

    public bool HasSpoiler { get; set; }
}
