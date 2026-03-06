using Telegram.BotAPI.Enums;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class UploadStickerFileParameters : ApiRequestParameters
{
    public required long UserId { get; init; }

    public required InputFile Sticker { get; init; }

    public required StickerFormat StickerFormat { get; init; }
}
