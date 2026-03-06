namespace Telegram.BotAPI.Parameters;

public sealed class CloseGeneralForumTopicParameters : ApiRequestParameters
{
    public required object ChatId { get; init; }
}
