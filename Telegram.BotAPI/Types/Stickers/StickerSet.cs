using System.Collections.Generic;
using Telegram.BotAPI.Types.AvailableTypes;

namespace Telegram.BotAPI.Types.Stickers;

/// <summary>
/// This object represents a sticker set.
/// </summary>
public sealed class StickerSet
{
    /// <summary>
    /// Sticker set name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Sticker set title
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Type of stickers in the set, currently one of “regular”, “mask”, “custom_emoji”
    /// </summary>
    public string StickerType { get; set; }

    /// <summary>
    /// List of all set stickers
    /// </summary>
    public List<Sticker> Stickers { get; set; }

    /// <summary>
    /// Optional. Sticker set thumbnail in the .WEBP, .TGS, or .WEBM format
    /// </summary>
    public PhotoSize Thumbnail { get; set; }

    public static class Types
    {
        public const string REGULAR = "regular";

        public const string MASK = "mask";

        public const string CUSTOM_EMOJI = "custom_emoji";
    }
}
