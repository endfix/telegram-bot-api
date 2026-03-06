namespace Telegram.BotAPI.Parameters;

public sealed class HideGeneralForumTopicParameters : ApiRequestParameters
{
    public required object ChatId { get; init; }
}
