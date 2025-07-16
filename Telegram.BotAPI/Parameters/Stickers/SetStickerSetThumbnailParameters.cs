namespace Telegram.BotAPI.Parameters;

public sealed class SetStickerSetThumbnailParameters : ApiRequestParameters
{
    public string Name { get; set; }

    public long UserId { get; set; }

    public object Thumbnail { get; set; }

    public string Format { get; set; }
}
