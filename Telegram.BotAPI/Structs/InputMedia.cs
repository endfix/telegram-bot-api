namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#inputmedia
    public abstract class InputMedia
    {
        public virtual string Type { get; set; }
        
        public virtual string Media { get; set; }

        public virtual string Caption { get; set; } = string.Empty;

        public virtual string ParseMode { get; set; } = "HTML";

        public virtual List<MessageEntity> CaptionEntities { get; set; }

        public sealed class Types
        {
            public const string ANIMATION = "animation";

            public const string DOCUMENT = "document";

            public const string AUDIO = "audio";

            public const string PHOTO = "photo";

            public const string VIDEO = "video";
        }

        // https://core.telegram.org/bots/api#inputmediaanimation
        public sealed class AnimationStruct : InputMedia
        {
            public override string Type => Types.ANIMATION;

            public string Thumbnail { get; set; } = string.Empty;

            public bool ShowCaptionAboveMedia { get; set; }

            public int Width { get; set; }

            public int Height { get; set; }

            public int Duration { get; set; }

            public bool HasSpoiler { get; set; }
        }

        // https://core.telegram.org/bots/api#inputmediaphoto
        public sealed class PhotoStruct : InputMedia
        {
            public override string Type => Types.PHOTO;

            public bool ShowCaptionAboveMedia { get; set; }

            public bool HasSpoiler { get; set; }
        }

        // https://core.telegram.org/bots/api#inputmediavideo
        public sealed class VideoStruct : InputMedia
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

        // https://core.telegram.org/bots/api#inputmediadocument
        public sealed class DocumentStruct : InputMedia
        {
            public override string Type => Types.DOCUMENT;

            public string Thumbnail { get; set; } = string.Empty;

            public bool DisableContentTypeDetection { get; set; }
        }

        // https://core.telegram.org/bots/api#inputmediaaudio
        public sealed class AudioStruct : InputMedia
        {
            public override string Type => Types.AUDIO;

            public string Thumbnail { get; set; } = string.Empty;

            public int Duration { get; set; }

            public string Performer { get; set; }

            public string Title { get; set; }
        }
    }
}
