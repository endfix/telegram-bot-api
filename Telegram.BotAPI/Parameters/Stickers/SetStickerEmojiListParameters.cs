using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setStickerEmojiList</c> method.
/// </summary>
public sealed class SetStickerEmojiListParameters : ApiRequestParameters
{
    /// <summary>File identifier of the sticker.</summary>
    public required string Sticker { get; init; }

    /// <summary>Emoji associated with the sticker.</summary>
    public required IReadOnlyList<string> EmojiList { get; init; }
}
