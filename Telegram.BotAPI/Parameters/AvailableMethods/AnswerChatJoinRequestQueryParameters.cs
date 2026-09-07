using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>answerChatJoinRequestQuery</c> method.
/// </summary>
public sealed class AnswerChatJoinRequestQueryParameters : ApiRequestParameters
{
    /// <summary>Gets the unique identifier of the join request query.</summary>
    public required string ChatJoinRequestQueryId { get; init; }

    /// <summary>Gets whether to approve, decline, or leave the decision to other administrators.</summary>
    public required AnswerChatJoinRequestQueryResult Result { get; init; }
}
