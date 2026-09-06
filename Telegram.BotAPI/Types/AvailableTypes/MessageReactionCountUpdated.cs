using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents an update to anonymous reaction counts on a message.</summary>
public sealed class MessageReactionCountUpdated
{
    /// <summary>Chat containing the message.</summary>
    public required Chat Chat { get; init; }

    /// <summary>Unique identifier of the message.</summary>
    public required long MessageId { get; init; }

    /// <summary>Date when the update occurred, in Unix time.</summary>
    public required long Date { get; init; }

    /// <summary>Current counts for the message's reactions.</summary>
    public required IReadOnlyList<ReactionCount> Reactions { get; init; }
}
