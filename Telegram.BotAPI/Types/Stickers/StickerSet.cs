using System.Collections.Generic;
using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public sealed class StickerSet
{
    public required string Name { get; init; }

    public required string Title { get; init; }

    public required StickerTypes StickerType { get; init; }

    public required IReadOnlyList<Sticker> Stickers { get; init; }

    public PhotoSize? Thumbnail { get; init; }
}
