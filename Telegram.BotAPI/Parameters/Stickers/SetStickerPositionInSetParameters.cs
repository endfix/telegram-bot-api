using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setStickerPositionInSet</c> method.
/// </summary>
public sealed class SetStickerPositionInSetParameters : ApiRequestParameters
{
    /// <summary>File identifier of the sticker.</summary>
    public required string Sticker { get; init; }

    /// <summary>Zero-based destination position.</summary>
    public required int Position { get; init; }
}
