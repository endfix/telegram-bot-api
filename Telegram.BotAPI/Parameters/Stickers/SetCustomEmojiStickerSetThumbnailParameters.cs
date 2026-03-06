namespace Telegram.BotAPI.Parameters;

public sealed class SetCustomEmojiStickerSetThumbnailParameters : ApiRequestParameters
{
    public required string Name { get; init; }

    public string? CustomEmojiId { get; init; }
}
