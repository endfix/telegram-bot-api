using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class ReopenGeneralForumTopicParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }
}
