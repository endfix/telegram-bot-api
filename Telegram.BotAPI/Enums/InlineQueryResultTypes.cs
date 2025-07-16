namespace Telegram.BotAPI.Enums;

public enum InlineQueryResultTypes
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
    CachedPhoto = Photo,
    CachedGif = Gif,
    CachedMpeg4Gif = Mpeg4Gif,
    CachedSticker,
    CachedDocument = Document,
    CachedVideo = Video,
    CachedVoice = Voice,
    CachedAudio = Audio
}
