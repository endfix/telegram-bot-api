using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>getStickerSet</c> method.
/// </summary>
public sealed class GetStickerSetParameters : ApiRequestParameters
{
    /// <summary>Sticker set name.</summary>
    public required string Name { get; init; }
}
