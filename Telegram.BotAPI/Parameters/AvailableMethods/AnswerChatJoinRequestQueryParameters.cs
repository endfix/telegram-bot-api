using Telegram.BotAPI.Enums;
using Telegram.BotAPI.Protocol;

namespace Telegram.BotAPI.Parameters;

public sealed class AnswerChatJoinRequestQueryParameters : ApiRequestParameters
{
    public required string ChatJoinRequestQueryId { get; init; }

    public required AnswerChatJoinRequestQueryResult Result { get; init; }
}
