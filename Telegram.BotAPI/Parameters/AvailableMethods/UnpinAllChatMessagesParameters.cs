namespace Telegram.BotAPI.Parameters;

public sealed class UnpinAllChatMessagesParameters : ApiRequestParameters
{
    public required object ChatId { get; init; }
}
