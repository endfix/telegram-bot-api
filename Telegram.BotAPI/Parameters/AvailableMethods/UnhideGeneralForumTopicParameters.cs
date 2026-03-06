namespace Telegram.BotAPI.Parameters;

public sealed class UnhideGeneralForumTopicParameters : ApiRequestParameters
{
    public required object ChatId { get; init; }
}
