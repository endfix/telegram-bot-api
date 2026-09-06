using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>getCustomEmojiStickers</c> method.
/// </summary>
public sealed class GetCustomEmojiStickersParameters : ApiRequestParameters
{
    /// <summary>Identifiers of the custom emoji.</summary>
    public required IReadOnlyList<string> CustomEmojiIds { get; init; }
}
