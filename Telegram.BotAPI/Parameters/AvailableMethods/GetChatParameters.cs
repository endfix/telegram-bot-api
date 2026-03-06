namespace Telegram.BotAPI.Parameters;

public sealed class GetChatParameters : ApiRequestParameters
{
    public required object ChatId { get; init; }
}
