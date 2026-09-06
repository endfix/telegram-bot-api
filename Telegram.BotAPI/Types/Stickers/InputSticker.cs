using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes a sticker to be added to a sticker set.
/// </summary>
public sealed class InputSticker
{
    /// <summary>Sticker file to add.</summary>
    public required StickerSource Sticker { get; init; }

    /// <summary>Format of the sticker.</summary>
    public required InputStickerFormat Format { get; init; }

    /// <summary>List of 1-20 emoji associated with the sticker.</summary>
    public required IReadOnlyList<string> EmojiList { get; init; }

    /// <summary>Optional mask position for the sticker.</summary>
    public MaskPosition? MaskPosition { get; init; }

    /// <summary>Optional list of search keywords for the sticker.</summary>
    public IReadOnlyList<string>? Keywords { get; init; }
}
