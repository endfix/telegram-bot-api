using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class SetStickerMaskPositionParameters : ApiRequestParameters
{
    public string Sticker { get; set; }

    public MaskPosition MaskPosition { get; set; }
}
