using System.Collections.Generic;

namespace Telegram.BotAPI.Types.Stickers;

// https://core.telegram.org/bots/api#inputsticker
public sealed class InputSticker
{
    public string Sticker { get; set; }

    public string Format { get; set; }

    public List<string> EmojiList { get; set; }

    public MaskPosition MaskPosition { get; set; }

    public List<string> Keywords { get; set; }

    public static class Formats
    {
        public const string STATIC = "static";

        public const string ANIMATED = "animated";

        public const string VIDEO = "video";
    }
}
