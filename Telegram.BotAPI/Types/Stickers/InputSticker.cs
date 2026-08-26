using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

public sealed class InputSticker
{
    public required StickerSource Sticker { get; init; }

    public required InputStickerFormat Format { get; init; }

    public required IReadOnlyList<string> EmojiList { get; init; }

    public MaskPosition? MaskPosition { get; init; }

    public IReadOnlyList<string>? Keywords { get; init; }
}
