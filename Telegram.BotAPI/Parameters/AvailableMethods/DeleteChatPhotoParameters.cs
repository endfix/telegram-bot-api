namespace Telegram.BotAPI.Parameters;

public sealed class DeleteChatPhotoParameters : ApiRequestParameters
{
    public required object ChatId { get; init; }
}
