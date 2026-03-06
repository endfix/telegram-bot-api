namespace Telegram.BotAPI.Parameters;

public sealed class GetChatAdministratorsParameters : ApiRequestParameters
{
    public required object ChatId { get; init; }
}
