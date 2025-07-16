namespace Telegram.BotAPI.Parameters;

public sealed class SetStickerPositionInSetParameters : ApiRequestParameters
{
    public string Sticker { get; set; }

    public int Position { get; set; }
}
