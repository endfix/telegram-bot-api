using Telegram.BotAPI.Enums;
using Telegram.BotAPI.Protocol;

namespace Telegram.BotAPI.Parameters;

public sealed class AnswerChatJoinRequestQueryParameters : ApiRequestParameters
{
    public required string chat_join_request_query_id { get; init; }

    public required AnswerChatJoinRequestQueryResult Result { get; init; }
}
