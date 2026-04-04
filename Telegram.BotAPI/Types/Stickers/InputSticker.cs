using System.Collections.Generic;
using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public sealed class InputSticker
{
    public required object Sticker { get; init; }

    public required InputStickerFormat Format { get; init; }

    public required IReadOnlyList<string> EmojiList { get; init; }

    public MaskPosition? MaskPosition { get; init; }

    public IReadOnlyList<string>? Keywords { get; init; }
}
