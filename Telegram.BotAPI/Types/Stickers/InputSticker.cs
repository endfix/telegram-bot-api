using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public sealed class InputSticker
{
    public object Sticker { get; set; }

    public InputStickerFormats Format { get; set; }

    public string[] EmojiList { get; set; }

    public MaskPosition MaskPosition { get; set; }

    public string[] Keywords { get; set; }
}
