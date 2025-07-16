namespace Telegram.BotAPI.Parameters;

public sealed class UnbanChatSenderChatParameters : ApiRequestParameters
{
    public object ChatId { get; set; }

    public long SenderChatId { get; set; }
}
