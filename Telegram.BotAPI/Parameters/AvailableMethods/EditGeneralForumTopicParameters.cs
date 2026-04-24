using Telegram.BotAPI.Protocol;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class EditGeneralForumTopicParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }

    public required string Name { get; init; }
}
