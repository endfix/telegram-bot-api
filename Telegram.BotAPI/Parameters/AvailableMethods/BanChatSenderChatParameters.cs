namespace Telegram.BotAPI.Parameters;

public sealed class BanChatSenderChatParameters : ApiRequestParameters
{
    public required string ChatId { get; init; }

    public required long SenderChatId { get; init; }
}
