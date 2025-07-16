namespace Telegram.BotAPI.Parameters;

public sealed class SetChatStickerSetParameters : ApiRequestParameters
{
    public object ChatId { set; get; }

    public string StickerSetName { set; get; }
}
