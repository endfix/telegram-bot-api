using System.Collections.Generic;
using Telegram.BotAPI.Types.AvailableTypes;

namespace Telegram.BotAPI.Types.InlineMode;

public abstract class InlineQueryResult
{
    public abstract string Type { get; }

    public virtual string Id { get; set; }

    public static class Types
    {
        public const string ARTICLE = "article";

        public const string AUDIO = "audio";

        public const string CONTACT = "contact";

        public const string GAME = "game";

        public const string DOCUMENT = "document";

        public const string GIF = "gif";

        public const string LOCATION = "location";

        public const string MPEG4_GIF = "mpeg4_gif";

        public const string PHOTO = "photo";

        public const string VENUE = "venue";

        public const string VIDEO = "video";

        public const string VOICE = "voice";

        public const string CACHED_PHOTO = PHOTO;

        public const string CACHED_GIF = GIF;

        public const string CACHED_MPEG4_GIF = MPEG4_GIF;

        public const string CACHED_STICKER = "sticker";

        public const string CACHED_DOCUMENT = DOCUMENT;

        public const string CACHED_VIDEO = VIDEO;

        public const string CACHED_VOICE = VOICE;

        public const string CACHED_AUDIO = AUDIO;
    }
}

public sealed class InlineQueryResultArticle : InlineQueryResult
{
    public override string Type => Types.ARTICLE;

    public string Title { get; set; }

    public InputMessageContent InputMessageContent { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    public string Url { get; set; }

    public bool HideUrl { get; set; }

    public string Description { get; set; }

    public string ThumbnailUrl { get; set; }

    public int ThumbnailWidth { get; set; }

    public int ThumbnailHeight { get; set; }
}

public sealed class InlineQueryResultPhoto : InlineQueryResult
{
    public override string Type => Types.PHOTO;

    public string PhotoUrl { get; set; }

    public string ThumbnailUrl { get; set; }

    public int PhotoWidth { get; set; }

    public int PhotoHeight { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string Caption { get; set; }

    public string ParseMode { get; set; }

    public List<MessageEntity> CaptionEntities { get; set; }

    public bool ShowCaptionAboveMedia { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    public InputMessageContent InputMessageContent { get; set; }
}

public sealed class InlineQueryResultGif : InlineQueryResult
{
    public override string Type => Types.GIF;

    public string GifUrl { get; set; }

    public int GifWidth { get; set; }

    public int GifHeight { get; set; }

    public int GifDuration { get; set; }

    public string ThumbnailUrl { get; set; }

    public string ThumbnailMimeType { get; set; }

    public string Title { get; set; }

    public string Caption { get; set; }

    public string ParseMode { get; set; }

    public List<MessageEntity> CaptionEntities { get; set; }

    public bool ShowCaptionAboveMedia { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    public InputMessageContent InputMessageContent { get; set; }
}

public sealed class InlineQueryResultMpeg4Gif : InlineQueryResult
{
    public override string Type => Types.MPEG4_GIF;

    public string Mpeg4Url { get; set; }

    public int Mpeg4Width { get; set; }

    public int Mpeg4Height { get; set; }

    public int Mpeg4Duration { get; set; }

    public string ThumbnailUrl { get; set; }

    public string ThumbnailMimeType { get; set; }

    public string Title { get; set; }

    public string Caption { get; set; }

    public string ParseMode { get; set; }

    public List<MessageEntity> CaptionEntities { get; set; }

    public bool ShowCaptionAboveMedia { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    public InputMessageContent InputMessageContent { get; set; }
}

public sealed class InlineQueryResultVideo : InlineQueryResult
{
    public override string Type => Types.VIDEO;

    public string VideoUrl { get; set; }

    public string MimeType { get; set; }

    public string ThumbnailUrl { get; set; }

    public string Title { get; set; }

    public string Caption { get; set; }

    public string ParseMode { get; set; }

    public List<MessageEntity> CaptionEntities { get; set; }

    public bool ShowCaptionAboveMedia { get; set; }

    public int VideoWidth { get; set; }

    public int VideoHeight { get; set; }

    public int VideoDuration { get; set; }

    public string Description { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    public InputMessageContent InputMessageContent { get; set; }
}

public sealed class InlineQueryResultAudio : InlineQueryResult
{
    public override string Type => Types.AUDIO;

    public string AudioUrl { get; set; }

    public string Title { get; set; }

    public string Caption { get; set; }

    public string ParseMode { get; set; }

    public List<MessageEntity> CaptionEntities { get; set; }

    public string Performer { get; set; }

    public int AudioDuration { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    public InputMessageContent InputMessageContent { get; set; }
}

public sealed class InlineQueryResultVoice : InlineQueryResult
{
    public override string Type => Types.VOICE;

    public string VoiceUrl { get; set; }

    public string Title { get; set; }

    public string Caption { get; set; }

    public string ParseMode { get; set; }

    public List<MessageEntity> CaptionEntities { get; set; }

    public int VoiceDuration { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    public InputMessageContent InputMessageContent { get; set; }
}

public sealed class InlineQueryResultDocument : InlineQueryResult
{
    public override string Type => Types.DOCUMENT;

    public string Title { get; set; }

    public string Caption { get; set; }

    public string ParseMode { get; set; }

    public List<MessageEntity> CaptionEntities { get; set; }

    public string DocumentUrl { get; set; }

    public string MimeType { get; set; }

    public string Description { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    public InputMessageContent InputMessageContent { get; set; }

    public string ThumbnailUrl { get; set; }

    public int ThumbnailWidth { get; set; }

    public int ThumbnailHeight { get; set; }
}

public sealed class InlineQueryResultLocation : InlineQueryResult
{
    public override string Type => Types.LOCATION;

    public float Latitude { get; set; }

    public float Longitude { get; set; }

    public string Title { get; set; }

    public float HorizontalAccuracy { get; set; }

    public int LivePeriod { get; set; }

    public int Heading { get; set; }

    public int ProximityAlertRadius { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    public InputMessageContent InputMessageContent { get; set; }

    public string ThumbnailUrl { get; set; }

    public int ThumbnailWidth { get; set; }

    public int ThumbnailHeight { get; set; }
}

public sealed class InlineQueryResultVenue : InlineQueryResult
{
    public override string Type => Types.VENUE;

    public float Latitude { get; set; }

    public float Longitude { get; set; }

    public string Title { get; set; }

    public string Address { get; set; }

    public string FoursquareId { get; set; }

    public string FoursquareType { get; set; }

    public string GooglePlaceId { get; set; }

    public string GooglePlaceType { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    public InputMessageContent InputMessageContent { get; set; }

    public string ThumbnailUrl { get; set; }

    public int ThumbnailWidth { get; set; }

    public int ThumbnailHeight { get; set; }
}

public sealed class InlineQueryResultContact : InlineQueryResult
{
    public override string Type => Types.CONTACT;

    public string PhoneNumber { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Vcard { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    public InputMessageContent InputMessageContent { get; set; }

    public string ThumbnailUrl { get; set; }

    public int ThumbnailWidth { get; set; }

    public int ThumbnailHeight { get; set; }
}

public sealed class InlineQueryResultGame : InlineQueryResult
{
    public override string Type => Types.GAME;

    public string GameShortName { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }
}

public sealed class InlineQueryResultCachedPhoto : InlineQueryResult
{
    public override string Type => Types.CACHED_PHOTO;

    public string PhotoFileId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string Caption { get; set; }

    public string ParseMode { get; set; }

    public List<MessageEntity> CaptionEntities { get; set; }

    public bool ShowCaptionAboveMedia { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    public InputMessageContent InputMessageContent { get; set; }
}

public sealed class InlineQueryResultCachedGif : InlineQueryResult
{
    public override string Type => Types.CACHED_GIF;

    public string GifFileId { get; set; }

    public string Title { get; set; }

    public string Caption { get; set; }

    public string ParseMode { get; set; }

    public List<MessageEntity> CaptionEntities { get; set; }

    public bool ShowCaptionAboveMedia { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    public InputMessageContent InputMessageContent { get; set; }
}

public sealed class InlineQueryResultCachedMpeg4Gif : InlineQueryResult
{
    public override string Type => Types.CACHED_MPEG4_GIF;

    public string Mpeg4FileId { get; set; }

    public string Title { get; set; }

    public string Caption { get; set; }

    public string ParseMode { get; set; }

    public List<MessageEntity> CaptionEntities { get; set; }

    public bool ShowCaptionAboveMedia { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    public InputMessageContent InputMessageContent { get; set; }
}

public sealed class InlineQueryResultCachedSticker : InlineQueryResult
{
    public override string Type => Types.CACHED_STICKER;

    public string StickerFileId { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    public InputMessageContent InputMessageContent { get; set; }
}

public sealed class InlineQueryResultCachedDocument : InlineQueryResult
{
    public override string Type => Types.CACHED_DOCUMENT;

    public string Title { get; set; }

    public string DocumentFileId { get; set; }

    public string Description { get; set; }

    public string Caption { get; set; }

    public string ParseMode { get; set; }

    public List<MessageEntity> CaptionEntities { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    public InputMessageContent InputMessageContent { get; set; }
}

public sealed class InlineQueryResultCachedVideo : InlineQueryResult
{
    public override string Type => Types.CACHED_VIDEO;

    public string VideoFileId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string Caption { get; set; }

    public string ParseMode { get; set; }

    public List<MessageEntity> CaptionEntities { get; set; }

    public bool ShowCaptionAboveMedia { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    public InputMessageContent InputMessageContent { get; set; }
}

public sealed class InlineQueryResultCachedVoice : InlineQueryResult
{
    public override string Type => Types.CACHED_VOICE;

    public string VoiceFileId { get; set; }

    public string Title { get; set; }

    public string Caption { get; set; }

    public string ParseMode { get; set; }

    public List<MessageEntity> CaptionEntities { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    public InputMessageContent InputMessageContent { get; set; }
}

public sealed class InlineQueryResultCachedAudio : InlineQueryResult
{
    public override string Type => Types.CACHED_AUDIO;

    public string AudioFileId { get; set; }

    public string Caption { get; set; }

    public string ParseMode { get; set; }

    public List<MessageEntity> CaptionEntities { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    public InputMessageContent InputMessageContent { get; set; }
}
