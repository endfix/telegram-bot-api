using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class HideGeneralForumTopicParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }
}
