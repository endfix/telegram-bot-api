namespace Telegram.BotAPI.Parameters;

public sealed class ReopenGeneralForumTopicParameters : ApiRequestParameters
{
    public required object ChatId { get; init; }
}
