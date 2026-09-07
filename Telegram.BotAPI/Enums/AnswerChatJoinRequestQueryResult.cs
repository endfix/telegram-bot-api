namespace Endfix.Telegram.BotAPI.Enums;

/// <summary>Specifies how a bot answers a chat join request query.</summary>
public enum AnswerChatJoinRequestQueryResult
{
    /// <summary>Approves the join request.</summary>
    Approve,

    /// <summary>Declines the join request.</summary>
    Decline,

    /// <summary>Places the join request in the approval queue.</summary>
    Queue
}
