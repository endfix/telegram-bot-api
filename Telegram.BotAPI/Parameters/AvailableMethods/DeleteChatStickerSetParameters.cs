namespace Telegram.BotAPI.Parameters;

public sealed class DeleteChatStickerSetParameters : ApiRequestParameters
{
    public required object ChatId { get; init; }
}
