namespace Telegram.BotAPI.Parameters;

public sealed class EditGeneralForumTopicParameters : ApiRequestParameters
{
    public required object ChatId { get; init; }

    public required string Name { get; init; }
}
