using Telegram.BotAPI.Protocol;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class DeleteForumTopicParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }

    public required int MessageThreadId { get; init; }
}
