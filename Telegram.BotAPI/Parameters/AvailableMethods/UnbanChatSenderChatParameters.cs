namespace Telegram.BotAPI.Parameters;

public sealed class UnbanChatSenderChatParameters : ApiRequestParameters
{
    public required object ChatId { get; init; }

    public required long SenderChatId { get; init; }
}
