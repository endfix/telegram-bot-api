using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Base type for a result returned from an inline query.</summary>
public abstract class InlineQueryResult
{
    /// <summary>Gets the inline result kind.</summary>
    public abstract InlineQueryResultType Type { get; }

    /// <summary>Unique identifier for this result.</summary>
    public required virtual string Id { get; init; }
}

/// <summary>Represents a text article result.</summary>
public sealed class InlineQueryResultArticle : InlineQueryResult
{
    /// <summary>Gets the article result kind.</summary>
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

/// <summary>Represents a photo result.</summary>
public sealed class InlineQueryResultPhoto : InlineQueryResult
{
    /// <summary>Gets the photo result kind.</summary>
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

/// <summary>Represents an animated GIF result.</summary>
public sealed class InlineQueryResultGif : InlineQueryResult
{
    /// <summary>Gets the GIF result kind.</summary>
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

/// <summary>Represents an MPEG-4 animation result.</summary>
public sealed class InlineQueryResultMpeg4Gif : InlineQueryResult
{
    /// <summary>Gets the MPEG-4 GIF result kind.</summary>
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

/// <summary>Represents a video result.</summary>
public sealed class InlineQueryResultVideo : InlineQueryResult
{
    /// <summary>Gets the video result kind.</summary>
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

/// <summary>Represents an audio result.</summary>
public sealed class InlineQueryResultAudio : InlineQueryResult
{
    /// <summary>Gets the audio result kind.</summary>
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

/// <summary>Represents a voice message result.</summary>
public sealed class InlineQueryResultVoice : InlineQueryResult
{
    /// <summary>Gets the voice result kind.</summary>
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

/// <summary>Represents a general document result.</summary>
public sealed class InlineQueryResultDocument : InlineQueryResult
{
    /// <summary>Gets the document result kind.</summary>
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

/// <summary>Represents a location result.</summary>
public sealed class InlineQueryResultLocation : InlineQueryResult
{
    /// <summary>Gets the location result kind.</summary>
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

/// <summary>Represents a venue result.</summary>
public sealed class InlineQueryResultVenue : InlineQueryResult
{
    /// <summary>Gets the venue result kind.</summary>
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

/// <summary>Represents a contact result.</summary>
public sealed class InlineQueryResultContact : InlineQueryResult
{
    /// <summary>Gets the contact result kind.</summary>
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

/// <summary>Represents a game result.</summary>
public sealed class InlineQueryResultGame : InlineQueryResult
{
    /// <summary>Gets the game result kind.</summary>
    public override InlineQueryResultType Type => InlineQueryResultType.Game;

    public required string GameShortName { get; init; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }
}

/// <summary>Represents a cached photo result.</summary>
public sealed class InlineQueryResultCachedPhoto : InlineQueryResult
{
    /// <summary>Gets the cached-photo result kind.</summary>
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

/// <summary>Represents a cached GIF result.</summary>
public sealed class InlineQueryResultCachedGif : InlineQueryResult
{
    /// <summary>Gets the cached-GIF result kind.</summary>
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

/// <summary>Represents a cached MPEG-4 animation result.</summary>
public sealed class InlineQueryResultCachedMpeg4Gif : InlineQueryResult
{
    /// <summary>Gets the cached MPEG-4 GIF result kind.</summary>
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

/// <summary>Represents a cached sticker result.</summary>
public sealed class InlineQueryResultCachedSticker : InlineQueryResult
{
    /// <summary>Gets the cached-sticker result kind.</summary>
    public override InlineQueryResultType Type => InlineQueryResultType.CachedSticker;

    public required string StickerFileId { get; init; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    public InputMessageContent? InputMessageContent { get; init; }
}

/// <summary>Represents a cached document result.</summary>
public sealed class InlineQueryResultCachedDocument : InlineQueryResult
{
    /// <summary>Gets the cached-document result kind.</summary>
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

/// <summary>Represents a cached video result.</summary>
public sealed class InlineQueryResultCachedVideo : InlineQueryResult
{
    /// <summary>Gets the cached-video result kind.</summary>
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

/// <summary>Represents a cached voice result.</summary>
public sealed class InlineQueryResultCachedVoice : InlineQueryResult
{
    /// <summary>Gets the cached-voice result kind.</summary>
    public override InlineQueryResultType Type => InlineQueryResultType.CachedVoice;

    public required string VoiceFileId { get; init; }

    public required string Title { get; init; }

    public string? Caption { get; init; }

    public string? ParseMode { get; init; }

    public MessageEntity[]? CaptionEntities { get; init; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    public InputMessageContent? InputMessageContent { get; init; }
}

/// <summary>Represents a cached audio result.</summary>
public sealed class InlineQueryResultCachedAudio : InlineQueryResult
{
    /// <summary>Gets the cached-audio result kind.</summary>
    public override InlineQueryResultType Type => InlineQueryResultType.CachedAudio;

    public required string AudioFileId { get; init; }

    public string? Caption { get; init; }

    public string? ParseMode { get; init; }

    public MessageEntity[]? CaptionEntities { get; init; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    public InputMessageContent? InputMessageContent { get; init; }
}
