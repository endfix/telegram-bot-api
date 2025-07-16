using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public sealed class StickerSet
{
    public string Name { get; set; }

    public string Title { get; set; }

    public StickerTypes StickerType { get; set; }

    public Sticker[] Stickers { get; set; }

    public PhotoSize Thumbnail { get; set; }
}
