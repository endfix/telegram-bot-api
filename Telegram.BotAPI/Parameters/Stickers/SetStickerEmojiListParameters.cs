using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setStickerEmojiList</c> method.
/// </summary>
public sealed class SetStickerEmojiListParameters : ApiRequestParameters
{
    public required string Sticker { get; init; }

    public required IReadOnlyList<string> EmojiList { get; init; }
}
