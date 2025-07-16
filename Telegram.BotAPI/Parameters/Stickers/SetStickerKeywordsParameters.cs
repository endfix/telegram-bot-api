namespace Telegram.BotAPI.Parameters;

public sealed class SetStickerKeywordsParameters : ApiRequestParameters
{
    public string Sticker { get; set; }

    public string[] Keywords { get; set; }
}
