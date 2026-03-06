using System.Collections.Generic;

namespace Telegram.BotAPI.Parameters;

public sealed class SetStickerEmojiListParameters : ApiRequestParameters
{
    public required string Sticker { get; init; }

    public required IReadOnlyList<string> EmojiList { get; init; }
}
