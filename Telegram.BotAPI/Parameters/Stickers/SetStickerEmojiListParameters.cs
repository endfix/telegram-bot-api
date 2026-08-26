using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class SetStickerEmojiListParameters : ApiRequestParameters
{
    public required string Sticker { get; init; }

    public required IReadOnlyList<string> EmojiList { get; init; }
}
