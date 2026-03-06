namespace Telegram.BotAPI.Parameters;

public sealed class LeaveChatParameters : ApiRequestParameters
{
    public required object ChatId { get; init; }
}
