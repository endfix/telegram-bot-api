namespace Telegram.BotAPI.Parameters;

public sealed class DeleteForumTopicParameters : ApiRequestParameters
{
    public required object ChatId { get; init; }

    public required int MessageThreadId { get; init; }
}
