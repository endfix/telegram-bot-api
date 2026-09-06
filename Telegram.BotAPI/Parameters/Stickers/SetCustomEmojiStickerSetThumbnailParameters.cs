using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setCustomEmojiStickerSetThumbnail</c> method.
/// </summary>
public sealed class SetCustomEmojiStickerSetThumbnailParameters : ApiRequestParameters
{
    public required string Name { get; init; }

    public string? CustomEmojiId { get; init; }
}
