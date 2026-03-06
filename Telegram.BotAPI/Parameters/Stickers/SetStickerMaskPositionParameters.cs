using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class SetStickerMaskPositionParameters : ApiRequestParameters
{
    public required string Sticker { get; init; }

    public MaskPosition? MaskPosition { get; init; }
}
