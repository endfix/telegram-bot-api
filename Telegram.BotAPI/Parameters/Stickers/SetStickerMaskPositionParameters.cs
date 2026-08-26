using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class SetStickerMaskPositionParameters : ApiRequestParameters
{
    public required string Sticker { get; init; }

    public MaskPosition? MaskPosition { get; init; }
}
