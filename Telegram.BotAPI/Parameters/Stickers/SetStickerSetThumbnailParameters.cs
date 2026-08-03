using Telegram.BotAPI.Enums;
using Telegram.BotAPI.Protocol;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class SetStickerSetThumbnailParameters : ApiRequestParameters
{
    public required string Name { get; init; }

    public required long UserId { get; init; }

    public ThumbnailSource? Thumbnail { get; init; }

    public required StickerFormat Format { get; init; }
}
