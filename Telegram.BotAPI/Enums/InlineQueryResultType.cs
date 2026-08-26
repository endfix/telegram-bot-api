namespace Endfix.Telegram.BotAPI.Enums;

public enum InlineQueryResultType
{
    Article,
    Audio,
    Contact,
    Game,
    Document,
    Gif,
    Location,
    Mpeg4Gif,
    Photo,
    Venue,
    Video,
    Voice,
    Sticker,
    CachedPhoto = Photo,
    CachedGif = Gif,
    CachedMpeg4Gif = Mpeg4Gif,
    CachedSticker = Sticker,
    CachedDocument = Document,
    CachedVideo = Video,
    CachedVoice = Voice,
    CachedAudio = Audio
}
