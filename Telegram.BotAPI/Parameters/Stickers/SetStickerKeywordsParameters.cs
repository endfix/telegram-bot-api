using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setStickerKeywords</c> method.
/// </summary>
public sealed class SetStickerKeywordsParameters : ApiRequestParameters
{
    /// <summary>File identifier of the sticker.</summary>
    public required string Sticker { get; init; }

    /// <summary>Search keywords; omit to remove them.</summary>
    public IReadOnlyList<string>? Keywords { get; init; }
}
