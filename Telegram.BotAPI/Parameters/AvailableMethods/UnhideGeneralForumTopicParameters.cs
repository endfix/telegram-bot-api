using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class UnhideGeneralForumTopicParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }
}
