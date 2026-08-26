using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

public abstract class InlineQueryResult
{
    public abstract InlineQueryResultType Type { get; }

    public required virtual string Id { get; init; }
}

public sealed class InlineQueryResultArticle : InlineQueryResult
{
    public override InlineQueryResultType Type => InlineQueryResultType.Article;

    public required string Title { get; init; }

    public required InputMessageContent InputMessageContent { get; init; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    public string? Url { get; init; }

    public string? Description { get; init; }

    public string? ThumbnailUrl { get; init; }

    public int? ThumbnailWidth { get; init; }

    public int? ThumbnailHeight { get; init; }
}

public sealed class InlineQueryResultPhoto : InlineQueryResult
{
    public override InlineQueryResultType Type => InlineQueryResultType.Photo;

    public required string PhotoUrl { get; init; }

    public required string ThumbnailUrl { get; init; }

    public int? PhotoWidth { get; init; }

    public int? PhotoHeight { get; init; }

    public string? Title { get; init; }

    public string? Description { get; init; }

    public string? Caption { get; init; }

    public string? ParseMode { get; init; }

    public MessageEntity[]? CaptionEntities { get; init; }

    public bool? ShowCaptionAboveMedia { get; init; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    public InputMessageContent? InputMessageContent { get; init; }
}

public sealed class InlineQueryResultGif : InlineQueryResult
{
    public override InlineQueryResultType Type => InlineQueryResultType.Gif;

    public required string GifUrl { get; init; }

    public int? GifWidth { get; init; }

    public int? GifHeight { get; init; }

    public int? GifDuration { get; init; }

    public required string ThumbnailUrl { get; init; }

    public string? ThumbnailMimeType { get; init; }

    public string? Title { get; init; }

    public string? Caption { get; init; }

    public string? ParseMode { get; init; }

    public MessageEntity[]? CaptionEntities { get; init; }

    public bool? ShowCaptionAboveMedia { get; init; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    public InputMessageContent? InputMessageContent { get; init; }
}

public sealed class InlineQueryResultMpeg4Gif : InlineQueryResult
{
    public override InlineQueryResultType Type => InlineQueryResultType.Mpeg4Gif;

    public required string Mpeg4Url { get; init; }

    public int? Mpeg4Width { get; init; }

    public int? Mpeg4Height { get; init; }

    public int? Mpeg4Duration { get; init; }

    public required string ThumbnailUrl { get; init; }

    public string? ThumbnailMimeType { get; init; }

    public string? Title { get; init; }

    public string? Caption { get; init; }

    public string? ParseMode { get; init; }

    public MessageEntity[]? CaptionEntities { get; init; }

    public bool? ShowCaptionAboveMedia { get; init; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    public InputMessageContent? InputMessageContent { get; init; }
}

public sealed class InlineQueryResultVideo : InlineQueryResult
{
    public override InlineQueryResultType Type => InlineQueryResultType.Video;

    public required string VideoUrl { get; init; }

    public required string MimeType { get; init; }

    public required string ThumbnailUrl { get; init; }

    public required string Title { get; init; }

    public string? Caption { get; init; }

    public string? ParseMode { get; init; }

    public MessageEntity[]? CaptionEntities { get; init; }

    public bool? ShowCaptionAboveMedia { get; init; }

    public int? VideoWidth { get; init; }

    public int? VideoHeight { get; init; }

    public int? VideoDuration { get; init; }

    public string? Description { get; init; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    public InputMessageContent? InputMessageContent { get; init; }
}

public sealed class InlineQueryResultAudio : InlineQueryResult
{
    public override InlineQueryResultType Type => InlineQueryResultType.Audio;

    public required string AudioUrl { get; init; }

    public required string Title { get; init; }

    public string? Caption { get; init; }

    public string? ParseMode { get; init; }

    public MessageEntity[]? CaptionEntities { get; init; }

    public string? Performer { get; init; }

    public int? AudioDuration { get; init; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    public InputMessageContent? InputMessageContent { get; init; }
}

public sealed class InlineQueryResultVoice : InlineQueryResult
{
    public override InlineQueryResultType Type => InlineQueryResultType.Voice;

    public required string VoiceUrl { get; init; }

    public required string Title { get; init; }

    public string? Caption { get; init; }

    public string? ParseMode { get; init; }

    public MessageEntity[]? CaptionEntities { get; init; }

    public int? VoiceDuration { get; init; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    public InputMessageContent? InputMessageContent { get; init; }
}

public sealed class InlineQueryResultDocument : InlineQueryResult
{
    public override InlineQueryResultType Type => InlineQueryResultType.Document;

    public required string Title { get; init; }

    public string? Caption { get; init; }

    public string? ParseMode { get; init; }

    public MessageEntity[]? CaptionEntities { get; init; }

    public required string DocumentUrl { get; init; }

    public required string MimeType { get; init; }

    public string? Description { get; init; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    public InputMessageContent? InputMessageContent { get; init; }

    public string? ThumbnailUrl { get; init; }

    public int? ThumbnailWidth { get; init; }

    public int? ThumbnailHeight { get; init; }
}

public sealed class InlineQueryResultLocation : InlineQueryResult
{
    public override InlineQueryResultType Type => InlineQueryResultType.Location;

    public required double Latitude { get; init; }

    public required double Longitude { get; init; }

    public required string Title { get; init; }

    public float? HorizontalAccuracy { get; init; }

    public int? LivePeriod { get; init; }

    public int? Heading { get; init; }

    public int? ProximityAlertRadius { get; init; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    public InputMessageContent? InputMessageContent { get; init; }

    public string? ThumbnailUrl { get; init; }

    public int? ThumbnailWidth { get; init; }

    public int? ThumbnailHeight { get; init; }
}

public sealed class InlineQueryResultVenue : InlineQueryResult
{
    public override InlineQueryResultType Type => InlineQueryResultType.Venue;

    public required double Latitude { get; init; }

    public required double Longitude { get; init; }

    public required string Title { get; init; }

    public required string Address { get; init; }

    public string? FoursquareId { get; init; }

    public string? FoursquareType { get; init; }

    public string? GooglePlaceId { get; init; }

    public string? GooglePlaceType { get; init; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    public InputMessageContent? InputMessageContent { get; init; }

    public string? ThumbnailUrl { get; init; }

    public int? ThumbnailWidth { get; init; }

    public int? ThumbnailHeight { get; init; }
}

public sealed class InlineQueryResultContact : InlineQueryResult
{
    public override InlineQueryResultType Type => InlineQueryResultType.Contact;

    public required string PhoneNumber { get; init; }

    public required string FirstName { get; init; }

    public string? LastName { get; init; }

    public string? VCard { get; init; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    public InputMessageContent? InputMessageContent { get; init; }

    public string? ThumbnailUrl { get; init; }

    public int? ThumbnailWidth { get; init; }

    public int? ThumbnailHeight { get; init; }
}

public sealed class InlineQueryResultGame : InlineQueryResult
{
    public override InlineQueryResultType Type => InlineQueryResultType.Game;

    public required string GameShortName { get; init; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }
}

public sealed class InlineQueryResultCachedPhoto : InlineQueryResult
{
    public override InlineQueryResultType Type => InlineQueryResultType.CachedPhoto;

    public required string PhotoFileId { get; init; }

    public string? Title { get; init; }

    public string? Description { get; init; }

    public string? Caption { get; init; }

    public string? ParseMode { get; init; }

    public MessageEntity[]? CaptionEntities { get; init; }

    public bool? ShowCaptionAboveMedia { get; init; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    public InputMessageContent? InputMessageContent { get; init; }
}

public sealed class InlineQueryResultCachedGif : InlineQueryResult
{
    public override InlineQueryResultType Type => InlineQueryResultType.CachedGif;

    public required string GifFileId { get; init; }

    public string? Title { get; init; }

    public string? Caption { get; init; }

    public string? ParseMode { get; init; }

    public MessageEntity[]? CaptionEntities { get; init; }

    public bool? ShowCaptionAboveMedia { get; init; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    public InputMessageContent? InputMessageContent { get; init; }
}

public sealed class InlineQueryResultCachedMpeg4Gif : InlineQueryResult
{
    public override InlineQueryResultType Type => InlineQueryResultType.CachedMpeg4Gif;

    public required string Mpeg4FileId { get; init; }

    public string? Title { get; init; }

    public string? Caption { get; init; }

    public string? ParseMode { get; init; }

    public MessageEntity[]? CaptionEntities { get; init; }

    public bool? ShowCaptionAboveMedia { get; init; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    public InputMessageContent? InputMessageContent { get; init; }
}

public sealed class InlineQueryResultCachedSticker : InlineQueryResult
{
    public override InlineQueryResultType Type => InlineQueryResultType.CachedSticker;

    public required string StickerFileId { get; init; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    public InputMessageContent? InputMessageContent { get; init; }
}

public sealed class InlineQueryResultCachedDocument : InlineQueryResult
{
    public override InlineQueryResultType Type => InlineQueryResultType.CachedDocument;

    public required string Title { get; init; }

    public required string DocumentFileId { get; init; }

    public string? Description { get; init; }

    public string? Caption { get; init; }

    public string? ParseMode { get; init; }

    public MessageEntity[]? CaptionEntities { get; init; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    public InputMessageContent? InputMessageContent { get; init; }
}

public sealed class InlineQueryResultCachedVideo : InlineQueryResult
{
    public override InlineQueryResultType Type => InlineQueryResultType.CachedVideo;

    public required string VideoFileId { get; init; }

    public required string Title { get; init; }

    public string? Description { get; init; }

    public string? Caption { get; init; }

    public string? ParseMode { get; init; }

    public MessageEntity[]? CaptionEntities { get; init; }

    public bool? ShowCaptionAboveMedia { get; init; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    public InputMessageContent? InputMessageContent { get; init; }
}

public sealed class InlineQueryResultCachedVoice : InlineQueryResult
{
    public override InlineQueryResultType Type => InlineQueryResultType.CachedVoice;

    public required string VoiceFileId { get; init; }

    public required string Title { get; init; }

    public string? Caption { get; init; }

    public string? ParseMode { get; init; }

    public MessageEntity[]? CaptionEntities { get; init; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    public InputMessageContent? InputMessageContent { get; init; }
}

public sealed class InlineQueryResultCachedAudio : InlineQueryResult
{
    public override InlineQueryResultType Type => InlineQueryResultType.CachedAudio;

    public required string AudioFileId { get; init; }

    public string? Caption { get; init; }

    public string? ParseMode { get; init; }

    public MessageEntity[]? CaptionEntities { get; init; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    public InputMessageContent? InputMessageContent { get; init; }
}
