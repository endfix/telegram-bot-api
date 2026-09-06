using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>uploadStickerFile</c> method.
/// </summary>
public sealed class UploadStickerFileParameters : ApiRequestParameters
{
    /// <summary>Identifier of the user who owns the sticker set.</summary>
    public required long UserId { get; init; }

    /// <summary>Sticker file to upload.</summary>
    public required InputFile Sticker { get; init; }

    /// <summary>Sticker format.</summary>
    public required StickerFormat StickerFormat { get; init; }
}
