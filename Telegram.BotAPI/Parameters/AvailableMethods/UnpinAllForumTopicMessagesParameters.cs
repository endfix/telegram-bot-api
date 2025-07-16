namespace Telegram.BotAPI.Parameters;

public sealed class UnpinAllForumTopicMessagesParameters : ApiRequestParameters
{
    public object ChatId { get; set; }

    public int MessageThreadId { set; get; }
}
