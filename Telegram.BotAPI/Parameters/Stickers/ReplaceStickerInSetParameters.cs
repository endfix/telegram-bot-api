using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class ReplaceStickerInSetParameters : ApiRequestParameters
{
    public long UserId { get; set; }

    public string Name { get; set; }

    public string OldSticker { get; set; }

    public InputSticker Sticker { get; set; }
}
