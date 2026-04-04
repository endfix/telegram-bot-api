using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class UnpinAllGeneralForumTopicMessagesParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }
}
