using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setCustomEmojiStickerSetThumbnail</c> method.
/// </summary>
public sealed class SetCustomEmojiStickerSetThumbnailParameters : ApiRequestParameters
{
    /// <summary>Sticker set name.</summary>
    public required string Name { get; init; }

    /// <summary>Custom emoji identifier; omit to remove the thumbnail.</summary>
    public string? CustomEmojiId { get; init; }
}
