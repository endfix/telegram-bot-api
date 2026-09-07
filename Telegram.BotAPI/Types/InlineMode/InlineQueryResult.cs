using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Base type for a result returned from an inline query.</summary>
public abstract class InlineQueryResult
{
    /// <summary>Gets the inline result kind.</summary>
    public abstract InlineQueryResultType Type { get; }

    /// <summary>Unique identifier for this result, from 1 through 64 bytes.</summary>
    public required virtual string Id { get; init; }
}

/// <summary>Represents a text article result.</summary>
public sealed class InlineQueryResultArticle : InlineQueryResult
{
    /// <summary>Gets the article result kind.</summary>
    public override InlineQueryResultType Type => InlineQueryResultType.Article;

    /// <summary>Title of the result.</summary>
    public required string Title { get; init; }

    /// <summary>Content of the message to send.</summary>
    public required InputMessageContent InputMessageContent { get; init; }

    /// <summary>Inline keyboard attached to the message.</summary>
    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    /// <summary>URL of the result.</summary>
    public string? Url { get; init; }

    /// <summary>Short description of the result.</summary>
    public string? Description { get; init; }

    /// <summary>URL of the result thumbnail.</summary>
    public string? ThumbnailUrl { get; init; }

    /// <summary>Thumbnail width.</summary>
    public int? ThumbnailWidth { get; init; }

    /// <summary>Thumbnail height.</summary>
    public int? ThumbnailHeight { get; init; }
}

/// <summary>Represents a photo result.</summary>
public sealed class InlineQueryResultPhoto : InlineQueryResult
{
    /// <summary>Gets the photo result kind.</summary>
    public override InlineQueryResultType Type => InlineQueryResultType.Photo;

    /// <summary>URL of a JPEG photo whose size does not exceed 5 MB.</summary>
    public required string PhotoUrl { get; init; }

    /// <summary>URL of the photo thumbnail.</summary>
    public required string ThumbnailUrl { get; init; }

    /// <summary>Photo width.</summary>
    public int? PhotoWidth { get; init; }

    /// <summary>Photo height.</summary>
    public int? PhotoHeight { get; init; }

    /// <summary>Title of the result.</summary>
    public string? Title { get; init; }

    /// <summary>Short description of the result.</summary>
    public string? Description { get; init; }

    /// <summary>Caption of the photo, from 0 through 1024 characters after entity parsing.</summary>
    public string? Caption { get; init; }

    /// <summary>Mode for parsing entities in <see cref="Caption"/>.</summary>
    public string? ParseMode { get; init; }

    /// <summary>Special entities in <see cref="Caption"/>; can be specified instead of <see cref="ParseMode"/>.</summary>
    public MessageEntity[]? CaptionEntities { get; init; }

    /// <summary>Whether to show the caption above the message media.</summary>
    public bool? ShowCaptionAboveMedia { get; init; }

    /// <summary>Inline keyboard attached to the message.</summary>
    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    /// <summary>Content of the message to send instead of the photo.</summary>
    public InputMessageContent? InputMessageContent { get; init; }
}

/// <summary>Represents an animated GIF result.</summary>
public sealed class InlineQueryResultGif : InlineQueryResult
{
    /// <summary>Gets the GIF result kind.</summary>
    public override InlineQueryResultType Type => InlineQueryResultType.Gif;

    /// <summary>URL of the GIF file.</summary>
    public required string GifUrl { get; init; }

    /// <summary>GIF width.</summary>
    public int? GifWidth { get; init; }

    /// <summary>GIF height.</summary>
    public int? GifHeight { get; init; }

    /// <summary>GIF duration in seconds.</summary>
    public int? GifDuration { get; init; }

    /// <summary>URL of a static JPEG/GIF or animated MPEG-4 thumbnail.</summary>
    public required string ThumbnailUrl { get; init; }

    /// <summary>Thumbnail MIME type: <c>image/jpeg</c>, <c>image/gif</c>, or <c>video/mp4</c>. Defaults to <c>image/jpeg</c>.</summary>
    public string? ThumbnailMimeType { get; init; }

    /// <summary>Title of the result.</summary>
    public string? Title { get; init; }

    /// <summary>Caption of the GIF, from 0 through 1024 characters after entity parsing.</summary>
    public string? Caption { get; init; }

    /// <summary>Mode for parsing entities in <see cref="Caption"/>.</summary>
    public string? ParseMode { get; init; }

    /// <summary>Special entities in <see cref="Caption"/>; can be specified instead of <see cref="ParseMode"/>.</summary>
    public MessageEntity[]? CaptionEntities { get; init; }

    /// <summary>Whether to show the caption above the message media.</summary>
    public bool? ShowCaptionAboveMedia { get; init; }

    /// <summary>Inline keyboard attached to the message.</summary>
    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    /// <summary>Content of the message to send instead of the GIF animation.</summary>
    public InputMessageContent? InputMessageContent { get; init; }
}

/// <summary>Represents an MPEG-4 animation result.</summary>
public sealed class InlineQueryResultMpeg4Gif : InlineQueryResult
{
    /// <summary>Gets the MPEG-4 GIF result kind.</summary>
    public override InlineQueryResultType Type => InlineQueryResultType.Mpeg4Gif;

    /// <summary>URL of the MPEG-4 animation.</summary>
    public required string Mpeg4Url { get; init; }

    /// <summary>Video width.</summary>
    public int? Mpeg4Width { get; init; }

    /// <summary>Video height.</summary>
    public int? Mpeg4Height { get; init; }

    /// <summary>Video duration in seconds.</summary>
    public int? Mpeg4Duration { get; init; }

    /// <summary>URL of a static JPEG/GIF or animated MPEG-4 thumbnail.</summary>
    public required string ThumbnailUrl { get; init; }

    /// <summary>Thumbnail MIME type: <c>image/jpeg</c>, <c>image/gif</c>, or <c>video/mp4</c>. Defaults to <c>image/jpeg</c>.</summary>
    public string? ThumbnailMimeType { get; init; }

    /// <summary>Title of the result.</summary>
    public string? Title { get; init; }

    /// <summary>Caption of the MPEG-4 animation, from 0 through 1024 characters after entity parsing.</summary>
    public string? Caption { get; init; }

    /// <summary>Mode for parsing entities in <see cref="Caption"/>.</summary>
    public string? ParseMode { get; init; }

    /// <summary>Special entities in <see cref="Caption"/>; can be specified instead of <see cref="ParseMode"/>.</summary>
    public MessageEntity[]? CaptionEntities { get; init; }

    /// <summary>Whether to show the caption above the message media.</summary>
    public bool? ShowCaptionAboveMedia { get; init; }

    /// <summary>Inline keyboard attached to the message.</summary>
    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    /// <summary>Content of the message to send instead of the video animation.</summary>
    public InputMessageContent? InputMessageContent { get; init; }
}

/// <summary>Represents a video result.</summary>
public sealed class InlineQueryResultVideo : InlineQueryResult
{
    /// <summary>Gets the video result kind.</summary>
    public override InlineQueryResultType Type => InlineQueryResultType.Video;

    /// <summary>URL of the embedded video player or video file.</summary>
    public required string VideoUrl { get; init; }

    /// <summary>Content MIME type of <see cref="VideoUrl"/>; must be <c>text/html</c> or <c>video/mp4</c>.</summary>
    public required string MimeType { get; init; }

    /// <summary>URL of the JPEG video thumbnail.</summary>
    public required string ThumbnailUrl { get; init; }

    /// <summary>Title of the result.</summary>
    public required string Title { get; init; }

    /// <summary>Caption of the video, from 0 through 1024 characters after entity parsing.</summary>
    public string? Caption { get; init; }

    /// <summary>Mode for parsing entities in <see cref="Caption"/>.</summary>
    public string? ParseMode { get; init; }

    /// <summary>Special entities in <see cref="Caption"/>; can be specified instead of <see cref="ParseMode"/>.</summary>
    public MessageEntity[]? CaptionEntities { get; init; }

    /// <summary>Whether to show the caption above the message media.</summary>
    public bool? ShowCaptionAboveMedia { get; init; }

    /// <summary>Video width.</summary>
    public int? VideoWidth { get; init; }

    /// <summary>Video height.</summary>
    public int? VideoHeight { get; init; }

    /// <summary>Video duration in seconds.</summary>
    public int? VideoDuration { get; init; }

    /// <summary>Short description of the result.</summary>
    public string? Description { get; init; }

    /// <summary>Inline keyboard attached to the message.</summary>
    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    /// <summary>Content to send instead of the video; required when <see cref="VideoUrl"/> points to an HTML page.</summary>
    public InputMessageContent? InputMessageContent { get; init; }
}

/// <summary>Represents an audio result.</summary>
public sealed class InlineQueryResultAudio : InlineQueryResult
{
    /// <summary>Gets the audio result kind.</summary>
    public override InlineQueryResultType Type => InlineQueryResultType.Audio;

    /// <summary>URL of the MP3 audio file.</summary>
    public required string AudioUrl { get; init; }

    /// <summary>Audio title.</summary>
    public required string Title { get; init; }

    /// <summary>Caption, from 0 through 1024 characters after entity parsing.</summary>
    public string? Caption { get; init; }

    /// <summary>Mode for parsing entities in <see cref="Caption"/>.</summary>
    public string? ParseMode { get; init; }

    /// <summary>Special entities in <see cref="Caption"/>; can be specified instead of <see cref="ParseMode"/>.</summary>
    public MessageEntity[]? CaptionEntities { get; init; }

    /// <summary>Audio performer.</summary>
    public string? Performer { get; init; }

    /// <summary>Audio duration in seconds.</summary>
    public int? AudioDuration { get; init; }

    /// <summary>Inline keyboard attached to the message.</summary>
    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    /// <summary>Content of the message to send instead of the audio.</summary>
    public InputMessageContent? InputMessageContent { get; init; }
}

/// <summary>Represents a voice message result.</summary>
public sealed class InlineQueryResultVoice : InlineQueryResult
{
    /// <summary>Gets the voice result kind.</summary>
    public override InlineQueryResultType Type => InlineQueryResultType.Voice;

    /// <summary>URL of the OGG voice recording encoded with OPUS.</summary>
    public required string VoiceUrl { get; init; }

    /// <summary>Voice recording title.</summary>
    public required string Title { get; init; }

    /// <summary>Caption, from 0 through 1024 characters after entity parsing.</summary>
    public string? Caption { get; init; }

    /// <summary>Mode for parsing entities in <see cref="Caption"/>.</summary>
    public string? ParseMode { get; init; }

    /// <summary>Special entities in <see cref="Caption"/>; can be specified instead of <see cref="ParseMode"/>.</summary>
    public MessageEntity[]? CaptionEntities { get; init; }

    /// <summary>Recording duration in seconds.</summary>
    public int? VoiceDuration { get; init; }

    /// <summary>Inline keyboard attached to the message.</summary>
    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    /// <summary>Content of the message to send instead of the voice recording.</summary>
    public InputMessageContent? InputMessageContent { get; init; }
}

/// <summary>Represents a general document result.</summary>
public sealed class InlineQueryResultDocument : InlineQueryResult
{
    /// <summary>Gets the document result kind.</summary>
    public override InlineQueryResultType Type => InlineQueryResultType.Document;

    /// <summary>Title of the result.</summary>
    public required string Title { get; init; }

    /// <summary>Caption of the document, from 0 through 1024 characters after entity parsing.</summary>
    public string? Caption { get; init; }

    /// <summary>Mode for parsing entities in <see cref="Caption"/>.</summary>
    public string? ParseMode { get; init; }

    /// <summary>Special entities in <see cref="Caption"/>; can be specified instead of <see cref="ParseMode"/>.</summary>
    public MessageEntity[]? CaptionEntities { get; init; }

    /// <summary>URL of the PDF or ZIP file.</summary>
    public required string DocumentUrl { get; init; }

    /// <summary>File MIME type; must be <c>application/pdf</c> or <c>application/zip</c>.</summary>
    public required string MimeType { get; init; }

    /// <summary>Short description of the result.</summary>
    public string? Description { get; init; }

    /// <summary>Inline keyboard attached to the message.</summary>
    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    /// <summary>Content of the message to send instead of the file.</summary>
    public InputMessageContent? InputMessageContent { get; init; }

    /// <summary>URL of the JPEG file thumbnail.</summary>
    public string? ThumbnailUrl { get; init; }

    /// <summary>Thumbnail width.</summary>
    public int? ThumbnailWidth { get; init; }

    /// <summary>Thumbnail height.</summary>
    public int? ThumbnailHeight { get; init; }
}

/// <summary>Represents a location result.</summary>
public sealed class InlineQueryResultLocation : InlineQueryResult
{
    /// <summary>Gets the location result kind.</summary>
    public override InlineQueryResultType Type => InlineQueryResultType.Location;

    /// <summary>Location latitude in degrees.</summary>
    public required double Latitude { get; init; }

    /// <summary>Location longitude in degrees.</summary>
    public required double Longitude { get; init; }

    /// <summary>Location title.</summary>
    public required string Title { get; init; }

    /// <summary>Radius of location uncertainty in meters, from 0 through 1500.</summary>
    public float? HorizontalAccuracy { get; init; }

    /// <summary>Update period for a live location, from 60 through 86400 seconds, or <see cref="int.MaxValue"/> for indefinite editing.</summary>
    public int? LivePeriod { get; init; }

    /// <summary>Movement direction for a live location in degrees, from 1 through 360.</summary>
    public int? Heading { get; init; }

    /// <summary>Maximum proximity-alert distance for a live location in meters, from 1 through 100000.</summary>
    public int? ProximityAlertRadius { get; init; }

    /// <summary>Inline keyboard attached to the message.</summary>
    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    /// <summary>Content of the message to send instead of the location.</summary>
    public InputMessageContent? InputMessageContent { get; init; }

    /// <summary>URL of the result thumbnail.</summary>
    public string? ThumbnailUrl { get; init; }

    /// <summary>Thumbnail width.</summary>
    public int? ThumbnailWidth { get; init; }

    /// <summary>Thumbnail height.</summary>
    public int? ThumbnailHeight { get; init; }
}

/// <summary>Represents a venue result.</summary>
public sealed class InlineQueryResultVenue : InlineQueryResult
{
    /// <summary>Gets the venue result kind.</summary>
    public override InlineQueryResultType Type => InlineQueryResultType.Venue;

    /// <summary>Venue latitude in degrees.</summary>
    public required double Latitude { get; init; }

    /// <summary>Venue longitude in degrees.</summary>
    public required double Longitude { get; init; }

    /// <summary>Venue title.</summary>
    public required string Title { get; init; }

    /// <summary>Venue address.</summary>
    public required string Address { get; init; }

    /// <summary>Foursquare venue identifier, if known.</summary>
    public string? FoursquareId { get; init; }

    /// <summary>Foursquare venue type, if known.</summary>
    public string? FoursquareType { get; init; }

    /// <summary>Google Places venue identifier.</summary>
    public string? GooglePlaceId { get; init; }

    /// <summary>Google Places venue type.</summary>
    public string? GooglePlaceType { get; init; }

    /// <summary>Inline keyboard attached to the message.</summary>
    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    /// <summary>Content of the message to send instead of the venue.</summary>
    public InputMessageContent? InputMessageContent { get; init; }

    /// <summary>URL of the result thumbnail.</summary>
    public string? ThumbnailUrl { get; init; }

    /// <summary>Thumbnail width.</summary>
    public int? ThumbnailWidth { get; init; }

    /// <summary>Thumbnail height.</summary>
    public int? ThumbnailHeight { get; init; }
}

/// <summary>Represents a contact result.</summary>
public sealed class InlineQueryResultContact : InlineQueryResult
{
    /// <summary>Gets the contact result kind.</summary>
    public override InlineQueryResultType Type => InlineQueryResultType.Contact;

    /// <summary>Contact's phone number.</summary>
    public required string PhoneNumber { get; init; }

    /// <summary>Contact's first name.</summary>
    public required string FirstName { get; init; }

    /// <summary>Contact's last name.</summary>
    public string? LastName { get; init; }

    /// <summary>Additional contact data in vCard format, from 0 through 2048 bytes.</summary>
    public string? VCard { get; init; }

    /// <summary>Inline keyboard attached to the message.</summary>
    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    /// <summary>Content of the message to send instead of the contact.</summary>
    public InputMessageContent? InputMessageContent { get; init; }

    /// <summary>URL of the result thumbnail.</summary>
    public string? ThumbnailUrl { get; init; }

    /// <summary>Thumbnail width.</summary>
    public int? ThumbnailWidth { get; init; }

    /// <summary>Thumbnail height.</summary>
    public int? ThumbnailHeight { get; init; }
}

/// <summary>Represents a game result.</summary>
public sealed class InlineQueryResultGame : InlineQueryResult
{
    /// <summary>Gets the game result kind.</summary>
    public override InlineQueryResultType Type => InlineQueryResultType.Game;

    /// <summary>Short name of the game.</summary>
    public required string GameShortName { get; init; }

    /// <summary>Inline keyboard attached to the message.</summary>
    public InlineKeyboardMarkup? ReplyMarkup { get; init; }
}

/// <summary>Represents a cached photo result.</summary>
public sealed class InlineQueryResultCachedPhoto : InlineQueryResult
{
    /// <summary>Gets the cached-photo result kind.</summary>
    public override InlineQueryResultType Type => InlineQueryResultType.CachedPhoto;

    /// <summary>Valid Telegram file identifier of the photo.</summary>
    public required string PhotoFileId { get; init; }

    /// <summary>Title of the result.</summary>
    public string? Title { get; init; }

    /// <summary>Short description of the result.</summary>
    public string? Description { get; init; }

    /// <summary>Caption of the photo, from 0 through 1024 characters after entity parsing.</summary>
    public string? Caption { get; init; }

    /// <summary>Mode for parsing entities in <see cref="Caption"/>.</summary>
    public string? ParseMode { get; init; }

    /// <summary>Special entities in <see cref="Caption"/>; can be specified instead of <see cref="ParseMode"/>.</summary>
    public MessageEntity[]? CaptionEntities { get; init; }

    /// <summary>Whether to show the caption above the message media.</summary>
    public bool? ShowCaptionAboveMedia { get; init; }

    /// <summary>Inline keyboard attached to the message.</summary>
    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    /// <summary>Content of the message to send instead of the photo.</summary>
    public InputMessageContent? InputMessageContent { get; init; }
}

/// <summary>Represents a cached GIF result.</summary>
public sealed class InlineQueryResultCachedGif : InlineQueryResult
{
    /// <summary>Gets the cached-GIF result kind.</summary>
    public override InlineQueryResultType Type => InlineQueryResultType.CachedGif;

    /// <summary>Valid Telegram file identifier of the GIF file.</summary>
    public required string GifFileId { get; init; }

    /// <summary>Title of the result.</summary>
    public string? Title { get; init; }

    /// <summary>Caption of the GIF, from 0 through 1024 characters after entity parsing.</summary>
    public string? Caption { get; init; }

    /// <summary>Mode for parsing entities in <see cref="Caption"/>.</summary>
    public string? ParseMode { get; init; }

    /// <summary>Special entities in <see cref="Caption"/>; can be specified instead of <see cref="ParseMode"/>.</summary>
    public MessageEntity[]? CaptionEntities { get; init; }

    /// <summary>Whether to show the caption above the message media.</summary>
    public bool? ShowCaptionAboveMedia { get; init; }

    /// <summary>Inline keyboard attached to the message.</summary>
    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    /// <summary>Content of the message to send instead of the GIF animation.</summary>
    public InputMessageContent? InputMessageContent { get; init; }
}

/// <summary>Represents a cached MPEG-4 animation result.</summary>
public sealed class InlineQueryResultCachedMpeg4Gif : InlineQueryResult
{
    /// <summary>Gets the cached MPEG-4 GIF result kind.</summary>
    public override InlineQueryResultType Type => InlineQueryResultType.CachedMpeg4Gif;

    /// <summary>Valid Telegram file identifier of the MPEG-4 animation.</summary>
    public required string Mpeg4FileId { get; init; }

    /// <summary>Title of the result.</summary>
    public string? Title { get; init; }

    /// <summary>Caption of the MPEG-4 animation, from 0 through 1024 characters after entity parsing.</summary>
    public string? Caption { get; init; }

    /// <summary>Mode for parsing entities in <see cref="Caption"/>.</summary>
    public string? ParseMode { get; init; }

    /// <summary>Special entities in <see cref="Caption"/>; can be specified instead of <see cref="ParseMode"/>.</summary>
    public MessageEntity[]? CaptionEntities { get; init; }

    /// <summary>Whether to show the caption above the message media.</summary>
    public bool? ShowCaptionAboveMedia { get; init; }

    /// <summary>Inline keyboard attached to the message.</summary>
    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    /// <summary>Content of the message to send instead of the video animation.</summary>
    public InputMessageContent? InputMessageContent { get; init; }
}

/// <summary>Represents a cached sticker result.</summary>
public sealed class InlineQueryResultCachedSticker : InlineQueryResult
{
    /// <summary>Gets the cached-sticker result kind.</summary>
    public override InlineQueryResultType Type => InlineQueryResultType.CachedSticker;

    /// <summary>Valid Telegram file identifier of the sticker.</summary>
    public required string StickerFileId { get; init; }

    /// <summary>Inline keyboard attached to the message.</summary>
    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    /// <summary>Content of the message to send instead of the sticker.</summary>
    public InputMessageContent? InputMessageContent { get; init; }
}

/// <summary>Represents a cached document result.</summary>
public sealed class InlineQueryResultCachedDocument : InlineQueryResult
{
    /// <summary>Gets the cached-document result kind.</summary>
    public override InlineQueryResultType Type => InlineQueryResultType.CachedDocument;

    /// <summary>Title of the result.</summary>
    public required string Title { get; init; }

    /// <summary>Valid Telegram file identifier of the document.</summary>
    public required string DocumentFileId { get; init; }

    /// <summary>Short description of the result.</summary>
    public string? Description { get; init; }

    /// <summary>Caption of the document, from 0 through 1024 characters after entity parsing.</summary>
    public string? Caption { get; init; }

    /// <summary>Mode for parsing entities in <see cref="Caption"/>.</summary>
    public string? ParseMode { get; init; }

    /// <summary>Special entities in <see cref="Caption"/>; can be specified instead of <see cref="ParseMode"/>.</summary>
    public MessageEntity[]? CaptionEntities { get; init; }

    /// <summary>Inline keyboard attached to the message.</summary>
    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    /// <summary>Content of the message to send instead of the document.</summary>
    public InputMessageContent? InputMessageContent { get; init; }
}

/// <summary>Represents a cached video result.</summary>
public sealed class InlineQueryResultCachedVideo : InlineQueryResult
{
    /// <summary>Gets the cached-video result kind.</summary>
    public override InlineQueryResultType Type => InlineQueryResultType.CachedVideo;

    /// <summary>Valid Telegram file identifier of the video.</summary>
    public required string VideoFileId { get; init; }

    /// <summary>Title of the result.</summary>
    public required string Title { get; init; }

    /// <summary>Short description of the result.</summary>
    public string? Description { get; init; }

    /// <summary>Caption of the video, from 0 through 1024 characters after entity parsing.</summary>
    public string? Caption { get; init; }

    /// <summary>Mode for parsing entities in <see cref="Caption"/>.</summary>
    public string? ParseMode { get; init; }

    /// <summary>Special entities in <see cref="Caption"/>; can be specified instead of <see cref="ParseMode"/>.</summary>
    public MessageEntity[]? CaptionEntities { get; init; }

    /// <summary>Whether to show the caption above the message media.</summary>
    public bool? ShowCaptionAboveMedia { get; init; }

    /// <summary>Inline keyboard attached to the message.</summary>
    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    /// <summary>Content of the message to send instead of the video.</summary>
    public InputMessageContent? InputMessageContent { get; init; }
}

/// <summary>Represents a cached voice result.</summary>
public sealed class InlineQueryResultCachedVoice : InlineQueryResult
{
    /// <summary>Gets the cached-voice result kind.</summary>
    public override InlineQueryResultType Type => InlineQueryResultType.CachedVoice;

    /// <summary>Valid Telegram file identifier of the voice message.</summary>
    public required string VoiceFileId { get; init; }

    /// <summary>Voice message title.</summary>
    public required string Title { get; init; }

    /// <summary>Caption, from 0 through 1024 characters after entity parsing.</summary>
    public string? Caption { get; init; }

    /// <summary>Mode for parsing entities in <see cref="Caption"/>.</summary>
    public string? ParseMode { get; init; }

    /// <summary>Special entities in <see cref="Caption"/>; can be specified instead of <see cref="ParseMode"/>.</summary>
    public MessageEntity[]? CaptionEntities { get; init; }

    /// <summary>Inline keyboard attached to the message.</summary>
    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    /// <summary>Content of the message to send instead of the voice message.</summary>
    public InputMessageContent? InputMessageContent { get; init; }
}

/// <summary>Represents a cached audio result.</summary>
public sealed class InlineQueryResultCachedAudio : InlineQueryResult
{
    /// <summary>Gets the cached-audio result kind.</summary>
    public override InlineQueryResultType Type => InlineQueryResultType.CachedAudio;

    /// <summary>Valid Telegram file identifier of the audio file.</summary>
    public required string AudioFileId { get; init; }

    /// <summary>Caption, from 0 through 1024 characters after entity parsing.</summary>
    public string? Caption { get; init; }

    /// <summary>Mode for parsing entities in <see cref="Caption"/>.</summary>
    public string? ParseMode { get; init; }

    /// <summary>Special entities in <see cref="Caption"/>; can be specified instead of <see cref="ParseMode"/>.</summary>
    public MessageEntity[]? CaptionEntities { get; init; }

    /// <summary>Inline keyboard attached to the message.</summary>
    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    /// <summary>Content of the message to send instead of the audio.</summary>
    public InputMessageContent? InputMessageContent { get; init; }
}
