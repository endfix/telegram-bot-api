namespace Telegram.BotAPI.Parameters;

public sealed class SendChatActionParameters : ApiRequestParameters
{
    public string BusinessConnectionId { get; set; }

    public object ChatId { get; set; }

    public int MessageThreadId { get; set; }

    public string Action { get; set; }
}
