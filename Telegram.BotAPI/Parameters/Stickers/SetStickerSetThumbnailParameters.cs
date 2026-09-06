using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setStickerSetThumbnail</c> method.
/// </summary>
public sealed class SetStickerSetThumbnailParameters : ApiRequestParameters
{
    /// <summary>Sticker set name.</summary>
    public required string Name { get; init; }

    /// <summary>Identifier of the user who owns the sticker set.</summary>
    public required long UserId { get; init; }

    /// <summary>New thumbnail; omit to remove it.</summary>
    public ThumbnailSource? Thumbnail { get; init; }

    /// <summary>Sticker format.</summary>
    public required StickerFormat Format { get; init; }
}
