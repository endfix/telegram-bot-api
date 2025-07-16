using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public abstract class InlineQueryResult
{
    public abstract InlineQueryResultTypes Type { get; }

    public virtual string Id { get; set; }
}

public sealed class InlineQueryResultArticle : InlineQueryResult
{
    public override InlineQueryResultTypes Type => InlineQueryResultTypes.Article;

    public string Title { get; set; }

    public InputMessageContent InputMessageContent { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    public string Url { get; set; }

    public string Description { get; set; }

    public string ThumbnailUrl { get; set; }

    public int ThumbnailWidth { get; set; }

    public int ThumbnailHeight { get; set; }
}

public sealed class InlineQueryResultPhoto : InlineQueryResult
{
    public override InlineQueryResultTypes Type => InlineQueryResultTypes.Photo;

    public string PhotoUrl { get; set; }

    public string ThumbnailUrl { get; set; }

    public int PhotoWidth { get; set; }

    public int PhotoHeight { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string Caption { get; set; }

    public string ParseMode { get; set; }

    public MessageEntity[] CaptionEntities { get; set; }

    public bool ShowCaptionAboveMedia { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    public InputMessageContent InputMessageContent { get; set; }
}

public sealed class InlineQueryResultGif : InlineQueryResult
{
    public override InlineQueryResultTypes Type => InlineQueryResultTypes.Gif;

    public string GifUrl { get; set; }

    public int GifWidth { get; set; }

    public int GifHeight { get; set; }

    public int GifDuration { get; set; }

    public string ThumbnailUrl { get; set; }

    public string ThumbnailMimeType { get; set; }

    public string Title { get; set; }

    public string Caption { get; set; }

    public string ParseMode { get; set; }

    public MessageEntity[] CaptionEntities { get; set; }

    public bool ShowCaptionAboveMedia { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    public InputMessageContent InputMessageContent { get; set; }
}

public sealed class InlineQueryResultMpeg4Gif : InlineQueryResult
{
    public override InlineQueryResultTypes Type => InlineQueryResultTypes.Mpeg4Gif;

    public string Mpeg4Url { get; set; }

    public int Mpeg4Width { get; set; }

    public int Mpeg4Height { get; set; }

    public int Mpeg4Duration { get; set; }

    public string ThumbnailUrl { get; set; }

    public string ThumbnailMimeType { get; set; }

    public string Title { get; set; }

    public string Caption { get; set; }

    public string ParseMode { get; set; }

    public MessageEntity[] CaptionEntities { get; set; }

    public bool ShowCaptionAboveMedia { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    public InputMessageContent InputMessageContent { get; set; }
}

public sealed class InlineQueryResultVideo : InlineQueryResult
{
    public override InlineQueryResultTypes Type => InlineQueryResultTypes.Video;

    public string VideoUrl { get; set; }

    public string MimeType { get; set; }

    public string ThumbnailUrl { get; set; }

    public string Title { get; set; }

    public string Caption { get; set; }

    public string ParseMode { get; set; }

    public MessageEntity[] CaptionEntities { get; set; }

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
    public override InlineQueryResultTypes Type => InlineQueryResultTypes.Audio;

    public string AudioUrl { get; set; }

    public string Title { get; set; }

    public string Caption { get; set; }

    public string ParseMode { get; set; }

    public MessageEntity[] CaptionEntities { get; set; }

    public string Performer { get; set; }

    public int AudioDuration { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    public InputMessageContent InputMessageContent { get; set; }
}

public sealed class InlineQueryResultVoice : InlineQueryResult
{
    public override InlineQueryResultTypes Type => InlineQueryResultTypes.Voice;

    public string VoiceUrl { get; set; }

    public string Title { get; set; }

    public string Caption { get; set; }

    public string ParseMode { get; set; }

    public MessageEntity[] CaptionEntities { get; set; }

    public int VoiceDuration { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    public InputMessageContent InputMessageContent { get; set; }
}

public sealed class InlineQueryResultDocument : InlineQueryResult
{
    public override InlineQueryResultTypes Type => InlineQueryResultTypes.Document;

    public string Title { get; set; }

    public string Caption { get; set; }

    public string ParseMode { get; set; }

    public MessageEntity[] CaptionEntities { get; set; }

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
    public override InlineQueryResultTypes Type => InlineQueryResultTypes.Location;

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
    public override InlineQueryResultTypes Type => InlineQueryResultTypes.Venue;

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
    public override InlineQueryResultTypes Type => InlineQueryResultTypes.Contact;

    public string PhoneNumber { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string VCard { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    public InputMessageContent InputMessageContent { get; set; }

    public string ThumbnailUrl { get; set; }

    public int ThumbnailWidth { get; set; }

    public int ThumbnailHeight { get; set; }
}

public sealed class InlineQueryResultGame : InlineQueryResult
{
    public override InlineQueryResultTypes Type => InlineQueryResultTypes.Game;

    public string GameShortName { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }
}

public sealed class InlineQueryResultCachedPhoto : InlineQueryResult
{
    public override InlineQueryResultTypes Type => InlineQueryResultTypes.CachedPhoto;

    public string PhotoFileId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string Caption { get; set; }

    public string ParseMode { get; set; }

    public MessageEntity[] CaptionEntities { get; set; }

    public bool ShowCaptionAboveMedia { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    public InputMessageContent InputMessageContent { get; set; }
}

public sealed class InlineQueryResultCachedGif : InlineQueryResult
{
    public override InlineQueryResultTypes Type => InlineQueryResultTypes.CachedGif;

    public string GifFileId { get; set; }

    public string Title { get; set; }

    public string Caption { get; set; }

    public string ParseMode { get; set; }

    public MessageEntity[] CaptionEntities { get; set; }

    public bool ShowCaptionAboveMedia { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    public InputMessageContent InputMessageContent { get; set; }
}

public sealed class InlineQueryResultCachedMpeg4Gif : InlineQueryResult
{
    public override InlineQueryResultTypes Type => InlineQueryResultTypes.CachedMpeg4Gif;

    public string Mpeg4FileId { get; set; }

    public string Title { get; set; }

    public string Caption { get; set; }

    public string ParseMode { get; set; }

    public MessageEntity[] CaptionEntities { get; set; }

    public bool ShowCaptionAboveMedia { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    public InputMessageContent InputMessageContent { get; set; }
}

public sealed class InlineQueryResultCachedSticker : InlineQueryResult
{
    public override InlineQueryResultTypes Type => InlineQueryResultTypes.CachedSticker;

    public string StickerFileId { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    public InputMessageContent InputMessageContent { get; set; }
}

public sealed class InlineQueryResultCachedDocument : InlineQueryResult
{
    public override InlineQueryResultTypes Type => InlineQueryResultTypes.CachedDocument;

    public string Title { get; set; }

    public string DocumentFileId { get; set; }

    public string Description { get; set; }

    public string Caption { get; set; }

    public string ParseMode { get; set; }

    public MessageEntity[] CaptionEntities { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    public InputMessageContent InputMessageContent { get; set; }
}

public sealed class InlineQueryResultCachedVideo : InlineQueryResult
{
    public override InlineQueryResultTypes Type => InlineQueryResultTypes.CachedVideo;

    public string VideoFileId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string Caption { get; set; }

    public string ParseMode { get; set; }

    public MessageEntity[] CaptionEntities { get; set; }

    public bool ShowCaptionAboveMedia { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    public InputMessageContent InputMessageContent { get; set; }
}

public sealed class InlineQueryResultCachedVoice : InlineQueryResult
{
    public override InlineQueryResultTypes Type => InlineQueryResultTypes.CachedVoice;

    public string VoiceFileId { get; set; }

    public string Title { get; set; }

    public string Caption { get; set; }

    public string ParseMode { get; set; }

    public MessageEntity[] CaptionEntities { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    public InputMessageContent InputMessageContent { get; set; }
}

public sealed class InlineQueryResultCachedAudio : InlineQueryResult
{
    public override InlineQueryResultTypes Type => InlineQueryResultTypes.CachedAudio;

    public string AudioFileId { get; set; }

    public string Caption { get; set; }

    public string ParseMode { get; set; }

    public MessageEntity[] CaptionEntities { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    public InputMessageContent InputMessageContent { get; set; }
}
