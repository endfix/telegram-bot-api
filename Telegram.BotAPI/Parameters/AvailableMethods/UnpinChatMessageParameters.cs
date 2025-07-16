namespace Telegram.BotAPI.Parameters;

public sealed class UnpinChatMessageParameters : ApiRequestParameters
{
    public string BusinessConnectionId { get; set; }

    public object ChatId { get; set; }

    public int MessageId { get; set; }
}
