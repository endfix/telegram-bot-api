namespace Telegram.BotAPI.Parameters;

public sealed class DeleteForumTopicParameters : ApiRequestParameters
{
    public object ChatId { get; set; }

    public int MessageThreadId { get; set; }
}
