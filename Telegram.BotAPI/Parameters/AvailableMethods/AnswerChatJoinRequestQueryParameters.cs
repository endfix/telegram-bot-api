using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>answerChatJoinRequestQuery</c> method.
/// </summary>
public sealed class AnswerChatJoinRequestQueryParameters : ApiRequestParameters
{
    public required string ChatJoinRequestQueryId { get; init; }

    public required AnswerChatJoinRequestQueryResult Result { get; init; }
}
