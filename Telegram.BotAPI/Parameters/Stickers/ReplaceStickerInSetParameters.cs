using Telegram.BotAPI.Protocol;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class ReplaceStickerInSetParameters : ApiRequestParameters
{
    public required long UserId { get; init; }

    public required string Name { get; init; }

    public required string OldSticker { get; init; }

    public required InputSticker Sticker { get; init; }
}
