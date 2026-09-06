using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Represents a sticker set.
/// </summary>
public sealed class StickerSet
{
    /// <summary>Sticker set name.</summary>
    public required string Name { get; init; }

    /// <summary>Sticker set title.</summary>
    public required string Title { get; init; }

    /// <summary>Type of stickers in the set.</summary>
    public required StickerType StickerType { get; init; }

    /// <summary>List of all set stickers.</summary>
    public required IReadOnlyList<Sticker> Stickers { get; init; }

    /// <summary>Optional sticker set thumbnail.</summary>
    public PhotoSize? Thumbnail { get; init; }
}
