namespace Telegram.BotAPI.Parameters;

public sealed class SetChatStickerSetParameters : ApiRequestParameters
{
    public required object ChatId { get; init; }

    public required string StickerSetName { get; init; }
}
