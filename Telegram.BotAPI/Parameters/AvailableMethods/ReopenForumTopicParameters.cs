namespace Telegram.BotAPI.Parameters;

public sealed class ReopenForumTopicParameters : ApiRequestParameters
{
    public object ChatId { get; set; }

    public int MessageThreadId { set; get; }
}
