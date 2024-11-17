using System.Collections.Generic;
using Telegram.BotAPI.Types.AvailableTypes;

namespace Telegram.BotAPI.Types.InlineMode;

/// <summary>
/// This object represents one result of an inline query. Telegram clients currently support results of the following 20 types:
/// <see cref="InlineQueryResultCachedAudio">InlineQueryResultCachedAudio</see> or 
/// <see cref="InlineQueryResultCachedDocument">InlineQueryResultCachedDocument</see> or 
/// <see cref="InlineQueryResultCachedGif">InlineQueryResultCachedGif</see> or 
/// <see cref="InlineQueryResultCachedMpeg4Gif">InlineQueryResultCachedMpeg4Gif</see> or 
/// <see cref="InlineQueryResultCachedPhoto">InlineQueryResultCachedPhoto</see> or 
/// <see cref="InlineQueryResultCachedSticker">InlineQueryResultCachedSticker</see> or 
/// <see cref="InlineQueryResultCachedVideo">InlineQueryResultCachedVideo</see> or 
/// <see cref="InlineQueryResultCachedVoice">InlineQueryResultCachedVoice</see> or 
/// <see cref="InlineQueryResultArticle">InlineQueryResultArticle</see> or 
/// <see cref="InlineQueryResultAudio">InlineQueryResultAudio</see> or 
/// <see cref="InlineQueryResultContact">InlineQueryResultContact</see> or 
/// <see cref="InlineQueryResultGame">InlineQueryResultGame</see> or 
/// <see cref="InlineQueryResultDocument">InlineQueryResultDocument</see> or 
/// <see cref="InlineQueryResultGif">InlineQueryResultGif</see> or 
/// <see cref="InlineQueryResultLocation">InlineQueryResultLocation</see> or 
/// <see cref="InlineQueryResultMpeg4Gif">InlineQueryResultMpeg4Gif</see> or 
/// <see cref="InlineQueryResultPhoto">InlineQueryResultPhoto</see> or 
/// <see cref="InlineQueryResultVenue">InlineQueryResultVenue</see> or 
/// <see cref="InlineQueryResultVideo">InlineQueryResultVideo</see> or 
/// <see cref="InlineQueryResultVoice">InlineQueryResultVoice</see>
/// </summary>
public abstract class InlineQueryResult
{
    public abstract string Type { get; }

    /// <summary>
    /// Unique identifier for this result, 1-64 Bytes
    /// </summary>
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

/// <summary>
/// Represents a link to an article or web page.
/// </summary>
public sealed class InlineQueryResultArticle : InlineQueryResult
{
    /// <summary>
    /// Type of the result, must be article
    /// </summary>
    public override string Type => Types.ARTICLE;

    /// <summary>
    /// Title of the result
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Content of the message to be sent
    /// </summary>
    public InputMessageContent InputMessageContent { get; set; }

    /// <summary>
    /// Optional. <see href="https://core.telegram.org/bots/features#inline-keyboards">Inline keyboard</see> attached to the message
    /// </summary>
    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    /// <summary>
    /// Optional. URL of the result
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// Optional. Pass True if you don't want the URL to be shown in the message
    /// </summary>
    public bool HideUrl { get; set; }

    /// <summary>
    /// Optional. Short description of the result
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Optional. Url of the thumbnail for the result
    /// </summary>
    public string ThumbnailUrl { get; set; }

    /// <summary>
    /// Optional. Thumbnail width
    /// </summary>
    public int ThumbnailWidth { get; set; }

    /// <summary>
    /// Optional. Thumbnail height
    /// </summary>
    public int ThumbnailHeight { get; set; }
}

/// <summary>
/// Represents a link to a photo. By default, this photo will be sent by the user with optional caption. Alternatively,
/// you can use input_message_content to send a message with the specified content instead of the photo.
/// </summary>
public sealed class InlineQueryResultPhoto : InlineQueryResult
{
    /// <summary>
    /// Type of the result, must be photo
    /// </summary>
    public override string Type => Types.PHOTO;

    /// <summary>
    /// A valid URL of the photo. Photo must be in JPEG format. Photo size must not exceed 5MB
    /// </summary>
    public string PhotoUrl { get; set; }

    /// <summary>
    /// URL of the thumbnail for the photo
    /// </summary>
    public string ThumbnailUrl { get; set; }

    /// <summary>
    /// Optional. Width of the photo
    /// </summary>
    public int PhotoWidth { get; set; }

    /// <summary>
    /// Optional. Height of the photo
    /// </summary>
    public int PhotoHeight { get; set; }

    /// <summary>
    /// Optional. Title for the result
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Optional. Short description of the result
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Optional. Caption of the photo to be sent, 0-1024 characters after entities parsing
    /// </summary>
    public string Caption { get; set; }

    /// <summary>
    /// Optional. Mode for parsing entities in the photo caption. 
    /// See <see href="https://core.telegram.org/bots/api#formatting-options">formatting options</see> for more details.
    /// </summary>
    public string ParseMode { get; set; }

    /// <summary>
    /// Optional. List of special entities that appear in the caption, which can be specified instead of parse_mode
    /// </summary>
    public List<MessageEntity> CaptionEntities { get; set; }

    /// <summary>
    /// Optional. Pass True, if the caption must be shown above the message media
    /// </summary>
    public bool ShowCaptionAboveMedia { get; set; }

    /// <summary>
    /// Optional. <see href="https://core.telegram.org/bots/features#inline-keyboards">Inline keyboard</see> attached to the message
    /// </summary>
    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    /// <summary>
    /// Optional. Content of the message to be sent instead of the photo
    /// </summary>
    public InputMessageContent InputMessageContent { get; set; }
}

/// <summary>
/// Represents a link to an animated GIF file. By default, this animated GIF file will be sent by the user with optional caption. Alternatively, 
/// you can use input_message_content to send a message with the specified content instead of the animation.
/// </summary>
public sealed class InlineQueryResultGif : InlineQueryResult
{
    /// <summary>
    /// Type of the result, must be gif
    /// </summary>
    public override string Type => Types.GIF;

    /// <summary>
    /// A valid URL for the GIF file. File size must not exceed 1MB
    /// </summary>
    public string GifUrl { get; set; }

    /// <summary>
    /// Optional. Width of the GIF
    /// </summary>
    public int GifWidth { get; set; }

    /// <summary>
    /// Optional. Height of the GIF
    /// </summary>
    public int GifHeight { get; set; }

    /// <summary>
    /// Optional. Duration of the GIF in seconds
    /// </summary>
    public int GifDuration { get; set; }

    /// <summary>
    /// URL of the static (JPEG or GIF) or animated (MPEG4) thumbnail for the result
    /// </summary>
    public string ThumbnailUrl { get; set; }

    /// <summary>
    /// Optional. MIME type of the thumbnail, must be one of “image/jpeg”, “image/gif”, or “video/mp4”. Defaults to “image/jpeg”
    /// </summary>
    public string ThumbnailMimeType { get; set; }

    /// <summary>
    /// Optional. Title for the result
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Optional. Caption of the GIF file to be sent, 0-1024 characters after entities parsing
    /// </summary>
    public string Caption { get; set; }

    /// <summary>
    /// Optional. Mode for parsing entities in the caption. See <see href="https://core.telegram.org/bots/api#formatting-options">formatting options</see> for more details.
    /// </summary>
    public string ParseMode { get; set; }

    /// <summary>
    /// Optional. List of special entities that appear in the caption, which can be specified instead of parse_mode
    /// </summary>
    public List<MessageEntity> CaptionEntities { get; set; }

    /// <summary>
    /// Optional. Pass True, if the caption must be shown above the message media
    /// </summary>
    public bool ShowCaptionAboveMedia { get; set; }

    /// <summary>
    /// Optional. <see href="https://core.telegram.org/bots/features#inline-keyboards">Inline keyboard</see> attached to the message
    /// </summary>
    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    /// <summary>
    /// Optional. Content of the message to be sent instead of the GIF animation
    /// </summary>
    public InputMessageContent InputMessageContent { get; set; }
}

/// <summary>
/// Represents a link to a video animation (H.264/MPEG-4 AVC video without sound). 
/// By default, this animated MPEG-4 file will be sent by the user with optional caption. 
/// Alternatively, you can use input_message_content to send a message with the specified content instead of the animation.
/// </summary>
public sealed class InlineQueryResultMpeg4Gif : InlineQueryResult
{
    /// <summary>
    /// Type of the result, must be mpeg4_gif
    /// </summary>
    public override string Type => Types.MPEG4_GIF;

    /// <summary>
    /// A valid URL for the MPEG4 file. File size must not exceed 1MB
    /// </summary>
    public string Mpeg4Url { get; set; }

    /// <summary>
    /// Optional. Video width
    /// </summary>
    public int Mpeg4Width { get; set; }

    /// <summary>
    /// Optional. Video height
    /// </summary>
    public int Mpeg4Height { get; set; }

    /// <summary>
    /// Optional. Video duration in seconds
    /// </summary>
    public int Mpeg4Duration { get; set; }

    /// <summary>
    /// URL of the static (JPEG or GIF) or animated (MPEG4) thumbnail for the result
    /// </summary>
    public string ThumbnailUrl { get; set; }

    /// <summary>
    /// Optional. MIME type of the thumbnail, must be one of “image/jpeg”, “image/gif”, or “video/mp4”. Defaults to “image/jpeg”
    /// </summary>
    public string ThumbnailMimeType { get; set; }

    /// <summary>
    /// Optional. Title for the result
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Optional. Caption of the MPEG-4 file to be sent, 0-1024 characters after entities parsing
    /// </summary>
    public string Caption { get; set; }

    /// <summary>
    /// Optional. Mode for parsing entities in the caption. 
    /// See <see href="https://core.telegram.org/bots/api#formatting-options">formatting options</see> for more details.
    /// </summary>
    public string ParseMode { get; set; }

    /// <summary>
    /// Optional. List of special entities that appear in the caption, which can be specified instead of parse_mode
    /// </summary>
    public List<MessageEntity> CaptionEntities { get; set; }

    /// <summary>
    /// Optional. Pass True, if the caption must be shown above the message media
    /// </summary>
    public bool ShowCaptionAboveMedia { get; set; }

    /// <summary>
    /// Optional. <see href="https://core.telegram.org/bots/features#inline-keyboards">Inline keyboard</see> attached to the message
    /// </summary>
    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    /// <summary>
    /// Optional. Content of the message to be sent instead of the video animation
    /// </summary>
    public InputMessageContent InputMessageContent { get; set; }
}

/// <summary>
/// Represents a link to a page containing an embedded video player or a video file. 
/// By default, this video file will be sent by the user with an optional caption. Alternatively, 
/// you can use input_message_content to send a message with the specified content instead of the video.
/// </summary>
/// <remarks>
/// If an InlineQueryResultVideo message contains an embedded video (e.g., YouTube), 
/// you must replace its content using input_message_content.
/// </remarks>
public sealed class InlineQueryResultVideo : InlineQueryResult
{
    /// <summary>
    /// Type of the result, must be video
    /// </summary>
    public override string Type => Types.VIDEO;

    /// <summary>
    /// A valid URL for the embedded video player or video file
    /// </summary>
    public string VideoUrl { get; set; }

    /// <summary>
    /// MIME type of the content of the video URL, “text/html” or “video/mp4”
    /// </summary>
    public string MimeType { get; set; }

    /// <summary>
    /// URL of the thumbnail (JPEG only) for the video
    /// </summary>
    public string ThumbnailUrl { get; set; }

    /// <summary>
    /// Title for the result
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Optional. Caption of the video to be sent, 0-1024 characters after entities parsing
    /// </summary>
    public string Caption { get; set; }

    /// <summary>
    /// Optional. Mode for parsing entities in the video caption. See <see href="https://core.telegram.org/bots/api#formatting-options">formatting options</see> for more details.
    /// </summary>
    public string ParseMode { get; set; }

    /// <summary>
    /// Optional. List of special entities that appear in the caption, which can be specified instead of parse_mode
    /// </summary>
    public List<MessageEntity> CaptionEntities { get; set; }

    /// <summary>
    /// Optional. Pass True, if the caption must be shown above the message media
    /// </summary>
    public bool ShowCaptionAboveMedia { get; set; }

    /// <summary>
    /// Optional. Video width
    /// </summary>
    public int VideoWidth { get; set; }

    /// <summary>
    /// Optional. Video height
    /// </summary>
    public int VideoHeight { get; set; }

    /// <summary>
    /// Optional. Video duration in seconds
    /// </summary>
    public int VideoDuration { get; set; }

    /// <summary>
    /// Optional. Short description of the result
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Optional. <see href="https://core.telegram.org/bots/features#inline-keyboards">Inline keyboard</see> attached to the message
    /// </summary>
    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    /// <summary>
    /// Optional. Content of the message to be sent instead of the video. 
    /// This field is required if InlineQueryResultVideo is used to send an HTML-page as a result (e.g., a YouTube video).
    /// </summary>
    public InputMessageContent InputMessageContent { get; set; }
}

/// <summary>
/// Represents a link to an MP3 audio file. By default, this audio file will be sent by the user. 
/// Alternatively, you can use input_message_content to send a message with the specified content instead of the audio.
/// </summary>
public sealed class InlineQueryResultAudio : InlineQueryResult
{
    /// <summary>
    /// Type of the result, must be audio
    /// </summary>
    public override string Type => Types.AUDIO;

    /// <summary>
    /// A valid URL for the audio file
    /// </summary>
    public string AudioUrl { get; set; }

    /// <summary>
    /// Title
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Optional. Caption, 0-1024 characters after entities parsing
    /// </summary>
    public string Caption { get; set; }

    /// <summary>
    /// Optional. Mode for parsing entities in the audio caption. See <see href="https://core.telegram.org/bots/api#formatting-options">formatting options</see> for more details.
    /// </summary>
    public string ParseMode { get; set; }

    /// <summary>
    /// Optional. List of special entities that appear in the caption, which can be specified instead of parse_mode
    /// </summary>
    public List<MessageEntity> CaptionEntities { get; set; }

    /// <summary>
    /// Optional. Performer
    /// </summary>
    public string Performer { get; set; }

    /// <summary>
    /// Optional. Audio duration in seconds
    /// </summary>
    public int AudioDuration { get; set; }

    /// <summary>
    /// Optional. <see href="https://core.telegram.org/bots/features#inline-keyboards">Inline keyboard</see> attached to the message
    /// </summary>
    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    /// <summary>
    /// Optional. Content of the message to be sent instead of the audio
    /// </summary>
    public InputMessageContent InputMessageContent { get; set; }
}

/// <summary>
/// Represents a link to a voice recording in an .OGG container encoded with OPUS. 
/// By default, this voice recording will be sent by the user. Alternatively, 
/// you can use input_message_content to send a message with the specified content instead of the the voice message.
/// </summary>
public sealed class InlineQueryResultVoice : InlineQueryResult
{
    /// <summary>
    /// Type of the result, must be voice
    /// </summary>
    public override string Type => Types.VOICE;

    /// <summary>
    /// A valid URL for the voice recording
    /// </summary>
    public string VoiceUrl { get; set; }

    /// <summary>
    /// Recording title
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Optional. Caption, 0-1024 characters after entities parsing
    /// </summary>
    public string Caption { get; set; }

    /// <summary>
    /// Optional. Mode for parsing entities in the voice message caption. See <see href="https://core.telegram.org/bots/api#formatting-options">formatting options</see> for more details.
    /// </summary>
    public string ParseMode { get; set; }

    /// <summary>
    /// Optional. List of special entities that appear in the caption, which can be specified instead of parse_mode
    /// </summary>
    public List<MessageEntity> CaptionEntities { get; set; }

    /// <summary>
    /// Optional. Recording duration in seconds
    /// </summary>
    public int VoiceDuration { get; set; }

    /// <summary>
    /// Optional. <see href="https://core.telegram.org/bots/features#inline-keyboards">Inline keyboard</see> attached to the message
    /// </summary>
    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    /// <summary>
    /// Optional. Content of the message to be sent instead of the voice recording
    /// </summary>
    public InputMessageContent InputMessageContent { get; set; }
}

/// <summary>
/// Represents a link to a file. By default, this file will be sent by the user with an optional caption. Alternatively, 
/// you can use input_message_content to send a message with the specified content instead of the file. 
/// Currently, only .PDF and .ZIP files can be sent using this method.
/// </summary>
public sealed class InlineQueryResultDocument : InlineQueryResult
{
    /// <summary>
    /// Type of the result, must be document
    /// </summary>
    public override string Type => Types.DOCUMENT;

    /// <summary>
    /// Title for the result
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Optional. Caption of the document to be sent, 0-1024 characters after entities parsing
    /// </summary>
    public string Caption { get; set; }

    /// <summary>
    /// Optional. Mode for parsing entities in the document caption. See <see href="https://core.telegram.org/bots/api#formatting-options">formatting options</see> for more details.
    /// </summary>
    public string ParseMode { get; set; }

    /// <summary>
    /// Optional. List of special entities that appear in the caption, which can be specified instead of parse_mode
    /// </summary>
    public List<MessageEntity> CaptionEntities { get; set; }

    /// <summary>
    /// A valid URL for the file
    /// </summary>
    public string DocumentUrl { get; set; }

    /// <summary>
    /// MIME type of the content of the file, either “application/pdf” or “application/zip”
    /// </summary>
    public string MimeType { get; set; }

    /// <summary>
    /// Optional. Short description of the result
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Optional. <see href="https://core.telegram.org/bots/features#inline-keyboards">Inline keyboard</see> attached to the message
    /// </summary>
    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    /// <summary>
    /// Optional. Content of the message to be sent instead of the file
    /// </summary>
    public InputMessageContent InputMessageContent { get; set; }

    /// <summary>
    /// Optional. URL of the thumbnail (JPEG only) for the file
    /// </summary>
    public string ThumbnailUrl { get; set; }

    /// <summary>
    /// Optional. Thumbnail width
    /// </summary>
    public int ThumbnailWidth { get; set; }

    /// <summary>
    /// Optional. Thumbnail height
    /// </summary>
    public int ThumbnailHeight { get; set; }
}

/// <summary>
/// Represents a location on a map. By default, the location will be sent by the user. 
/// Alternatively, you can use input_message_content to send a message with the specified content instead of the location.
/// </summary>
public sealed class InlineQueryResultLocation : InlineQueryResult
{
    /// <summary>
    /// Type of the result, must be location
    /// </summary>
    public override string Type => Types.LOCATION;

    /// <summary>
    /// Location latitude in degrees
    /// </summary>
    public float Latitude { get; set; }

    /// <summary>
    /// Location longitude in degrees
    /// </summary>
    public float Longitude { get; set; }

    /// <summary>
    /// Location title
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Optional. The radius of uncertainty for the location, measured in meters; 0-1500
    /// </summary>
    public float HorizontalAccuracy { get; set; }

    /// <summary>
    /// Optional. Period in seconds during which the location can be updated, should be between 60 and 86400, 
    /// or 0x7FFFFFFF for live locations that can be edited indefinitely.
    /// </summary>
    public int LivePeriod { get; set; }

    /// <summary>
    /// Optional. For live locations, a direction in which the user is moving, in degrees. Must be between 1 and 360 if specified.
    /// </summary>
    public int Heading { get; set; }

    /// <summary>
    /// Optional. For live locations, a maximum distance for proximity alerts about approaching another chat member, 
    /// in meters. Must be between 1 and 100000 if specified.
    /// </summary>
    public int ProximityAlertRadius { get; set; }

    /// <summary>
    /// Optional. <see href="https://core.telegram.org/bots/features#inline-keyboards">Inline keyboard</see> attached to the message
    /// </summary>
    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    /// <summary>
    /// Optional. Content of the message to be sent instead of the location
    /// </summary>
    public InputMessageContent InputMessageContent { get; set; }

    /// <summary>
    /// Optional. Url of the thumbnail for the result
    /// </summary>
    public string ThumbnailUrl { get; set; }

    /// <summary>
    /// Optional. Thumbnail width
    /// </summary>
    public int ThumbnailWidth { get; set; }

    /// <summary>
    /// Optional. Thumbnail height
    /// </summary>
    public int ThumbnailHeight { get; set; }
}

/// <summary>
/// Represents a venue. By default, the venue will be sent by the user. Alternatively, you can use input_message_content to send a message with the specified content instead of the venue.
/// </summary>
public sealed class InlineQueryResultVenue : InlineQueryResult
{
    /// <summary>
    /// Type of the result, must be venue
    /// </summary>
    public override string Type => Types.VENUE;

    /// <summary>
    /// Latitude of the venue location in degrees
    /// </summary>
    public float Latitude { get; set; }

    /// <summary>
    /// Longitude of the venue location in degrees
    /// </summary>
    public float Longitude { get; set; }

    /// <summary>
    /// Title of the venue
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Address of the venue
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// Optional. Foursquare identifier of the venue if known
    /// </summary>
    public string FoursquareId { get; set; }

    /// <summary>
    /// Optional. Foursquare type of the venue, if known. (For example, “arts_entertainment/default”, “arts_entertainment/aquarium” or “food/icecream”.)
    /// </summary>
    public string FoursquareType { get; set; }

    /// <summary>
    /// Optional. Google Places identifier of the venue
    /// </summary>
    public string GooglePlaceId { get; set; }

    /// <summary>
    /// Optional. Google Places type of the venue. (See <see href="https://developers.google.com/places/web-service/supported_types">supported types</see>.)
    /// </summary>
    public string GooglePlaceType { get; set; }

    /// <summary>
    /// Optional. <see href="https://core.telegram.org/bots/features#inline-keyboards">Inline keyboard</see> attached to the message
    /// </summary>
    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    /// <summary>
    /// Optional. Content of the message to be sent instead of the venue
    /// </summary>
    public InputMessageContent InputMessageContent { get; set; }

    /// <summary>
    /// Optional. Url of the thumbnail for the result
    /// </summary>
    public string ThumbnailUrl { get; set; }

    /// <summary>
    /// Optional. Thumbnail width
    /// </summary>
    public int ThumbnailWidth { get; set; }

    /// <summary>
    /// Optional. Thumbnail height
    /// </summary>
    public int ThumbnailHeight { get; set; }
}

/// <summary>
/// Represents a contact with a phone number. By default, this contact will be sent by the user. 
/// Alternatively, you can use input_message_content to send a message with the specified content instead of the contact.
/// </summary>
public sealed class InlineQueryResultContact : InlineQueryResult
{
    /// <summary>
    /// Type of the result, must be contact
    /// </summary>
    public override string Type => Types.CONTACT;

    /// <summary>
    /// Contact's phone number
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// Contact's first name
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Optional. Contact's last name
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Optional. Additional data about the contact in the form of a <see href="https://en.wikipedia.org/wiki/VCard">vCard</see>, 0-2048 bytes
    /// </summary>
    public string VCard { get; set; }

    /// <summary>
    /// Optional. <see href="https://core.telegram.org/bots/features#inline-keyboards">Inline keyboard</see> attached to the message
    /// </summary>
    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    /// <summary>
    /// Optional. Content of the message to be sent instead of the contact
    /// </summary>
    public InputMessageContent InputMessageContent { get; set; }

    /// <summary>
    /// Optional. Url of the thumbnail for the result
    /// </summary>
    public string ThumbnailUrl { get; set; }

    /// <summary>
    /// Optional. Thumbnail width
    /// </summary>
    public int ThumbnailWidth { get; set; }

    /// <summary>
    /// Optional. Thumbnail height
    /// </summary>
    public int ThumbnailHeight { get; set; }
}

/// <summary>
/// Represents a <see href="https://core.telegram.org/bots/api#games">Game</see>.
/// </summary>
public sealed class InlineQueryResultGame : InlineQueryResult
{
    /// <summary>
    /// Type of the result, must be game
    /// </summary>
    public override string Type => Types.GAME;

    /// <summary>
    /// Short name of the game
    /// </summary>
    public string GameShortName { get; set; }

    /// <summary>
    /// Optional. <see href="https://core.telegram.org/bots/features#inline-keyboards">Inline keyboard</see> attached to the message
    /// </summary>
    public InlineKeyboardMarkup ReplyMarkup { get; set; }
}

/// <summary>
/// Represents a link to a photo stored on the Telegram servers. By default, this photo will be sent by the user with an optional caption.
/// Alternatively, you can use input_message_content to send a message with the specified content instead of the photo.
/// </summary>
public sealed class InlineQueryResultCachedPhoto : InlineQueryResult
{
    /// <summary>
    /// Type of the result, must be photo
    /// </summary>
    public override string Type => Types.CACHED_PHOTO;

    /// <summary>
    /// A valid file identifier of the photo
    /// </summary>
    public string PhotoFileId { get; set; }

    /// <summary>
    /// Optional. Title for the result
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Optional. Short description of the result
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Optional. Caption of the photo to be sent, 0-1024 characters after entities parsing
    /// </summary>
    public string Caption { get; set; }

    /// <summary>
    /// Optional. Mode for parsing entities in the photo caption. 
    /// See <see href="https://core.telegram.org/bots/api#formatting-options">formatting options</see> for more details.
    /// </summary>
    public string ParseMode { get; set; }

    /// <summary>
    /// Optional. List of special entities that appear in the caption, which can be specified instead of parse_mode
    /// </summary>
    public List<MessageEntity> CaptionEntities { get; set; }

    /// <summary>
    /// Optional. Pass True, if the caption must be shown above the message media
    /// </summary>
    public bool ShowCaptionAboveMedia { get; set; }

    /// <summary>
    /// Optional. <see href="https://core.telegram.org/bots/features#inline-keyboards">Inline keyboard</see> attached to the message
    /// </summary>
    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    /// <summary>
    /// Optional. Content of the message to be sent instead of the photo
    /// </summary>
    public InputMessageContent InputMessageContent { get; set; }
}

/// <summary>
/// Represents a link to an animated GIF file stored on the Telegram servers. 
/// By default, this animated GIF file will be sent by the user with an optional caption. 
/// Alternatively, you can use input_message_content to send a message with specified content instead of the animation.
/// </summary>
public sealed class InlineQueryResultCachedGif : InlineQueryResult
{
    /// <summary>
    /// Type of the result, must be gif
    /// </summary>
    public override string Type => Types.CACHED_GIF;

    /// <summary>
    /// A valid file identifier for the GIF file
    /// </summary>
    public string GifFileId { get; set; }

    /// <summary>
    /// Optional. Title for the result
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Optional. Caption of the GIF file to be sent, 0-1024 characters after entities parsing
    /// </summary>
    public string Caption { get; set; }

    /// <summary>
    /// Optional. Mode for parsing entities in the caption. See <see href="https://core.telegram.org/bots/api#formatting-options">formatting options</see> for more details.
    /// </summary>
    public string ParseMode { get; set; }

    /// <summary>
    /// Optional. List of special entities that appear in the caption, which can be specified instead of parse_mode
    /// </summary>
    public List<MessageEntity> CaptionEntities { get; set; }

    /// <summary>
    /// Optional. Pass True, if the caption must be shown above the message media
    /// </summary>
    public bool ShowCaptionAboveMedia { get; set; }

    /// <summary>
    /// Optional. <see href="https://core.telegram.org/bots/features#inline-keyboards">Inline keyboard</see> attached to the message
    /// </summary>
    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    /// <summary>
    /// Optional. Content of the message to be sent instead of the GIF animation
    /// </summary>
    public InputMessageContent InputMessageContent { get; set; }
}

/// <summary>
/// Represents a link to a video animation (H.264/MPEG-4 AVC video without sound) stored on the Telegram servers. 
/// By default, this animated MPEG-4 file will be sent by the user with an optional caption. Alternatively, 
/// you can use input_message_content to send a message with the specified content instead of the animation.
/// </summary>
public sealed class InlineQueryResultCachedMpeg4Gif : InlineQueryResult
{
    /// <summary>
    /// Type of the result, must be mpeg4_gif
    /// </summary>
    public override string Type => Types.CACHED_MPEG4_GIF;

    /// <summary>
    /// A valid file identifier for the MPEG4 file
    /// </summary>
    public string Mpeg4FileId { get; set; }

    /// <summary>
    /// Optional. Title for the result
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Optional. Caption of the MPEG-4 file to be sent, 0-1024 characters after entities parsing
    /// </summary>
    public string Caption { get; set; }

    /// <summary>
    /// Optional. Mode for parsing entities in the caption. See <see href="https://core.telegram.org/bots/api#formatting-options">formatting options</see> for more details.
    /// </summary>
    public string ParseMode { get; set; }

    /// <summary>
    /// Optional. List of special entities that appear in the caption, which can be specified instead of parse_mode
    /// </summary>
    public List<MessageEntity> CaptionEntities { get; set; }

    /// <summary>
    /// Optional. Pass True, if the caption must be shown above the message media
    /// </summary>
    public bool ShowCaptionAboveMedia { get; set; }

    /// <summary>
    /// Optional. <see href="https://core.telegram.org/bots/features#inline-keyboards">Inline keyboard</see> attached to the message
    /// </summary>
    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    /// <summary>
    /// Optional. Content of the message to be sent instead of the video animation
    /// </summary>
    public InputMessageContent InputMessageContent { get; set; }
}

/// <summary>
/// Represents a link to a sticker stored on the Telegram servers. 
/// By default, this sticker will be sent by the user. 
/// Alternatively, you can use input_message_content to send a message with the specified content instead of the sticker.
/// </summary>
public sealed class InlineQueryResultCachedSticker : InlineQueryResult
{
    /// <summary>
    /// Type of the result, must be sticker
    /// </summary>
    public override string Type => Types.CACHED_STICKER;

    /// <summary>
    /// A valid file identifier of the sticker
    /// </summary>
    public string StickerFileId { get; set; }

    /// <summary>
    /// Optional. <see href="https://core.telegram.org/bots/features#inline-keyboards">Inline keyboard</see> attached to the message
    /// </summary>
    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    /// <summary>
    /// Optional. Content of the message to be sent instead of the sticker
    /// </summary>
    public InputMessageContent InputMessageContent { get; set; }
}

/// <summary>
/// Represents a link to a file stored on the Telegram servers. 
/// By default, this file will be sent by the user with an optional caption. Alternatively, 
/// you can use input_message_content to send a message with the specified content instead of the file.
/// </summary>
public sealed class InlineQueryResultCachedDocument : InlineQueryResult
{
    /// <summary>
    /// Type of the result, must be document
    /// </summary>
    public override string Type => Types.CACHED_DOCUMENT;

    /// <summary>
    /// Title for the result
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// A valid file identifier for the file
    /// </summary>
    public string DocumentFileId { get; set; }

    /// <summary>
    /// Optional. Short description of the result
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Optional. Caption of the document to be sent, 0-1024 characters after entities parsing
    /// </summary>
    public string Caption { get; set; }

    /// <summary>
    /// Optional. Mode for parsing entities in the document caption. 
    /// See <see href="https://core.telegram.org/bots/api#formatting-options">formatting options</see> for more details.
    /// </summary>
    public string ParseMode { get; set; }

    /// <summary>
    /// Optional. List of special entities that appear in the caption, which can be specified instead of parse_mode
    /// </summary>
    public List<MessageEntity> CaptionEntities { get; set; }

    /// <summary>
    /// Optional. <see href="https://core.telegram.org/bots/features#inline-keyboards">Inline keyboard</see> attached to the message
    /// </summary>
    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    /// <summary>
    /// Optional. Content of the message to be sent instead of the file
    /// </summary>
    public InputMessageContent InputMessageContent { get; set; }
}

/// <summary>
/// Represents a link to a video file stored on the Telegram servers. 
/// By default, this video file will be sent by the user with an optional caption. 
/// Alternatively, you can use input_message_content to send a message with the specified content instead of the video.
/// </summary>
public sealed class InlineQueryResultCachedVideo : InlineQueryResult
{
    /// <summary>
    /// Type of the result, must be video
    /// </summary>
    public override string Type => Types.CACHED_VIDEO;

    /// <summary>
    /// A valid file identifier for the video file
    /// </summary>
    public string VideoFileId { get; set; }

    /// <summary>
    /// Title for the result
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Optional. Short description of the result
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Optional. Caption of the video to be sent, 0-1024 characters after entities parsing
    /// </summary>
    public string Caption { get; set; }

    /// <summary>
    /// Optional. Mode for parsing entities in the video caption. See <see href="https://core.telegram.org/bots/api#formatting-options">formatting options</see> for more details.
    /// </summary>
    public string ParseMode { get; set; }

    /// <summary>
    /// Optional. List of special entities that appear in the caption, which can be specified instead of parse_mode
    /// </summary>
    public List<MessageEntity> CaptionEntities { get; set; }

    /// <summary>
    /// Optional. Pass True, if the caption must be shown above the message media
    /// </summary>
    public bool ShowCaptionAboveMedia { get; set; }

    /// <summary>
    /// Optional. <see href="https://core.telegram.org/bots/features#inline-keyboards">Inline keyboard</see> attached to the message
    /// </summary>
    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    /// <summary>
    /// Optional. Content of the message to be sent instead of the video
    /// </summary>
    public InputMessageContent InputMessageContent { get; set; }
}

/// <summary>
/// Represents a link to a voice message stored on the Telegram servers. By default, this voice message will be sent by the user. 
/// Alternatively, you can use input_message_content to send a message with the specified content instead of the voice message.
/// </summary>
public sealed class InlineQueryResultCachedVoice : InlineQueryResult
{
    /// <summary>
    /// Type of the result, must be voice
    /// </summary>
    public override string Type => Types.CACHED_VOICE;

    /// <summary>
    /// A valid file identifier for the voice message
    /// </summary>
    public string VoiceFileId { get; set; }

    /// <summary>
    /// Voice message title
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Optional. Caption, 0-1024 characters after entities parsing
    /// </summary>
    public string Caption { get; set; }

    /// <summary>
    /// Optional. Mode for parsing entities in the voice message caption. 
    /// See <see href="https://core.telegram.org/bots/api#formatting-options">formatting options</see> for more details.
    /// </summary>
    public string ParseMode { get; set; }

    /// <summary>
    /// Optional. List of special entities that appear in the caption, which can be specified instead of parse_mode
    /// </summary>
    public List<MessageEntity> CaptionEntities { get; set; }

    /// <summary>
    /// Optional. <see href="https://core.telegram.org/bots/features#inline-keyboards">Inline keyboard</see> attached to the message
    /// </summary>
    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    /// <summary>
    /// Optional. Content of the message to be sent instead of the voice message
    /// </summary>
    public InputMessageContent InputMessageContent { get; set; }
}

/// <summary>
/// Represents a link to an MP3 audio file stored on the Telegram servers. 
/// By default, this audio file will be sent by the user. Alternatively, 
/// you can use input_message_content to send a message with the specified content instead of the audio.
/// </summary>
public sealed class InlineQueryResultCachedAudio : InlineQueryResult
{
    /// <summary>
    /// Type of the result, must be audio
    /// </summary>
    public override string Type => Types.CACHED_AUDIO;

    /// <summary>
    /// A valid file identifier for the audio file
    /// </summary>
    public string AudioFileId { get; set; }

    /// <summary>
    /// Optional. Caption, 0-1024 characters after entities parsing
    /// </summary>
    public string Caption { get; set; }

    /// <summary>
    /// Optional. Mode for parsing entities in the audio caption. See <see href="https://core.telegram.org/bots/api#formatting-options">formatting options</see> for more details.
    /// </summary>
    public string ParseMode { get; set; }

    /// <summary>
    /// Optional. List of special entities that appear in the caption, which can be specified instead of parse_mode
    /// </summary>
    public List<MessageEntity> CaptionEntities { get; set; }

    /// <summary>
    /// Optional. <see href="https://core.telegram.org/bots/features#inline-keyboards">Inline keyboard</see> attached to the message
    /// </summary>
    public InlineKeyboardMarkup ReplyMarkup { get; set; }

    /// <summary>
    /// Optional. Content of the message to be sent instead of the audio
    /// </summary>
    public InputMessageContent InputMessageContent { get; set; }
}
