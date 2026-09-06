using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setStickerMaskPosition</c> method.
/// </summary>
public sealed class SetStickerMaskPositionParameters : ApiRequestParameters
{
    /// <summary>File identifier of the sticker.</summary>
    public required string Sticker { get; init; }

    /// <summary>New mask position; omit to remove it.</summary>
    public MaskPosition? MaskPosition { get; init; }
}
