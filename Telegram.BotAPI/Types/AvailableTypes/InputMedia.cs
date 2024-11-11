using System.Collections.Generic;

namespace Telegram.BotAPI.Types.AvailableTypes;

public abstract class InputMedia
{
    public abstract string Type { get; }

    public virtual string Media { get; set; }

    public virtual string Caption { get; set; }

    public virtual string ParseMode { get; set; }

    public virtual List<MessageEntity> CaptionEntities { get; set; }

    public static class Types
    {
        public const string ANIMATION = "animation";

        public const string DOCUMENT = "document";

        public const string AUDIO = "audio";

        public const string PHOTO = "photo";

        public const string VIDEO = "video";
    }
}

public sealed class InputMediaAnimation : InputMedia
{
    public override string Type => Types.ANIMATION;

    public string Thumbnail { get; set; } = string.Empty;

    public bool ShowCaptionAboveMedia { get; set; }

    public int Width { get; set; }

    public int Height { get; set; }

    public int Duration { get; set; }

    public bool HasSpoiler { get; set; }
}

public sealed class InputMediaDocument : InputMedia
{
    public override string Type => Types.DOCUMENT;

    public string Thumbnail { get; set; } = string.Empty;

    public bool DisableContentTypeDetection { get; set; }
}

public sealed class InputMediaAudio : InputMedia
{
    public override string Type => Types.AUDIO;

    public string Thumbnail { get; set; } = string.Empty;

    public int Duration { get; set; }

    public string Performer { get; set; }

    public string Title { get; set; }
}

public sealed class InputMediaPhoto : InputMedia
{
    public override string Type => Types.PHOTO;

    public bool ShowCaptionAboveMedia { get; set; }

    public bool HasSpoiler { get; set; }
}

public sealed class InputMediaVideo : InputMedia
{
    public override string Type => Types.VIDEO;

    public string Thumbnail { get; set; } = string.Empty;

    public bool ShowCaptionAboveMedia { get; set; }

    public int Width { get; set; }

    public int Height { get; set; }

    public int Duration { get; set; }

    public bool SupportsStreaming { get; set; } = true;

    public bool HasSpoiler { get; set; }
}
