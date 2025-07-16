namespace Telegram.BotAPI.Parameters;

public sealed class SetCustomEmojiStickerSetThumbnailParameters : ApiRequestParameters
{
    public string Name { get; set; }

    public string CustomEmojiId { get; set; }
}
