using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents a reaction change on a message.</summary>
public sealed class MessageReactionUpdated
{
    /// <summary>Chat containing the message.</summary>
    public required Chat Chat { get; init; }

    /// <summary>Unique identifier of the message.</summary>
    public required long MessageId { get; init; }

    /// <summary>User who changed the reaction, if available.</summary>
    public User? User { get; init; }

    /// <summary>Chat that changed the reaction, if the reaction was made on behalf of a chat.</summary>
    public Chat? ActorChat { get; init; }

    /// <summary>Date when the change occurred, in Unix time.</summary>
    public required long Date { get; init; }

    /// <summary>Previous reactions set by the user or chat.</summary>
    public required IReadOnlyList<ReactionType> OldReaction { get; init; }

    /// <summary>New reactions set by the user or chat.</summary>
    public required IReadOnlyList<ReactionType> NewReaction { get; init; }
}
