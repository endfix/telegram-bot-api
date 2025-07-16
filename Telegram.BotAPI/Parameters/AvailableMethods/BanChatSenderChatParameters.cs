namespace Telegram.BotAPI.Parameters;

public sealed class BanChatSenderChatParameters : ApiRequestParameters
{
    public string ChatId { get; set; }

    public long SenderChatId { get; set; }
}
