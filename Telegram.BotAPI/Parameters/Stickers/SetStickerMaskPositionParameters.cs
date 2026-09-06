using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setStickerMaskPosition</c> method.
/// </summary>
public sealed class SetStickerMaskPositionParameters : ApiRequestParameters
{
    public required string Sticker { get; init; }

    public MaskPosition? MaskPosition { get; init; }
}
