using System.Collections.Generic;

namespace Telegram.BotAPI.Types.Stickers;

// https://core.telegram.org/bots/api#stickerset
public sealed class StickerSet
{
    public string Name { get; set; }

    public string Title { get; set; }

    public string StickerType { get; set; }

    public List<Sticker> Stickers { get; set; }

    public PhotoSize Thumbnail { get; set; }

    public static class Types
    {
        public const string REGULAR = "regular";

        public const string MASK = "mask";

        public const string CUSTOM_EMOJI = "custom_emoji";
    }
}
