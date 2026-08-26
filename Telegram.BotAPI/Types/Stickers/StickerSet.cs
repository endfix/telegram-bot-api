using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

public sealed class StickerSet
{
    public required string Name { get; init; }

    public required string Title { get; init; }

    public required StickerType StickerType { get; init; }

    public required IReadOnlyList<Sticker> Stickers { get; init; }

    public PhotoSize? Thumbnail { get; init; }
}
