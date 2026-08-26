using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class AddStickerToSetParameters : ApiRequestParameters
{
    public required long UserId { get; init; }

    public required string Name { get; init; }

    public required InputSticker Sticker { get; init; }
}
