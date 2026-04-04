using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class CloseGeneralForumTopicParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }
}
