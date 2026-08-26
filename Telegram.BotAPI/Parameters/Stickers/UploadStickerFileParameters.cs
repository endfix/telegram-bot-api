using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class UploadStickerFileParameters : ApiRequestParameters
{
    public required long UserId { get; init; }

    public required InputFile Sticker { get; init; }

    public required StickerFormat StickerFormat { get; init; }
}
