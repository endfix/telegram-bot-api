namespace Telegram.BotAPI.Parameters;

public sealed class SetStickerEmojiListParameters : ApiRequestParameters
{
    public string Sticker { get; set; }

    public string[] EmojiList { get; set; }
}
