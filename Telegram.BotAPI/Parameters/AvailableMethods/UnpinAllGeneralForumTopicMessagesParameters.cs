namespace Telegram.BotAPI.Parameters;

public sealed class UnpinAllGeneralForumTopicMessagesParameters : ApiRequestParameters
{
    public required object ChatId { get; init; }
}
