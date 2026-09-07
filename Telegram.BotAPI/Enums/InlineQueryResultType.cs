namespace Endfix.Telegram.BotAPI.Enums;

/// <summary>Identifies the content kind of an inline query result.</summary>
public enum InlineQueryResultType
{
    /// <summary>An article or web-page link.</summary>
    Article,

    /// <summary>An audio file.</summary>
    Audio,

    /// <summary>A contact.</summary>
    Contact,

    /// <summary>A Telegram game.</summary>
    Game,

    /// <summary>A general document.</summary>
    Document,

    /// <summary>An animated GIF.</summary>
    Gif,

    /// <summary>A geographic location.</summary>
    Location,

    /// <summary>An H.264/MPEG-4 animation without sound.</summary>
    Mpeg4Gif,

    /// <summary>A photo.</summary>
    Photo,

    /// <summary>A venue.</summary>
    Venue,

    /// <summary>A video.</summary>
    Video,

    /// <summary>A voice recording.</summary>
    Voice,

    /// <summary>A sticker.</summary>
    Sticker,

    /// <summary>A cached photo; serialized with the same discriminator as <see cref="Photo"/>.</summary>
    CachedPhoto = Photo,

    /// <summary>A cached GIF; serialized with the same discriminator as <see cref="Gif"/>.</summary>
    CachedGif = Gif,

    /// <summary>A cached MPEG-4 animation; serialized with the same discriminator as <see cref="Mpeg4Gif"/>.</summary>
    CachedMpeg4Gif = Mpeg4Gif,

    /// <summary>A cached sticker; serialized with the same discriminator as <see cref="Sticker"/>.</summary>
    CachedSticker = Sticker,

    /// <summary>A cached document; serialized with the same discriminator as <see cref="Document"/>.</summary>
    CachedDocument = Document,

    /// <summary>A cached video; serialized with the same discriminator as <see cref="Video"/>.</summary>
    CachedVideo = Video,

    /// <summary>A cached voice recording; serialized with the same discriminator as <see cref="Voice"/>.</summary>
    CachedVoice = Voice,

    /// <summary>A cached audio file; serialized with the same discriminator as <see cref="Audio"/>.</summary>
    CachedAudio = Audio
}
