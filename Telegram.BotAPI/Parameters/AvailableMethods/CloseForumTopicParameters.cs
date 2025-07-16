namespace Telegram.BotAPI.Parameters;

public sealed class CloseForumTopicParameters : ApiRequestParameters
{
    public object ChatId { get; set; }

    public int MessageThreadId { set; get; }
}
