using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class SetStickerSetThumbnailParameters : ApiRequestParameters
{
    public required string Name { get; init; }

    public required long UserId { get; init; }

    public ThumbnailSource? Thumbnail { get; init; }

    public required StickerFormat Format { get; init; }
}
