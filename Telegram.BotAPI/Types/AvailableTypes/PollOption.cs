using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents one answer option in a poll.</summary>
public sealed class PollOption
{
    /// <summary>Persistent identifier of the option.</summary>
    public required string PersistentId { get; init; }

    /// <summary>Text of the option.</summary>
    public required string Text { get; init; }

    /// <summary>Special entities that appear in the option text, if available.</summary>
    public IReadOnlyList<MessageEntity>? TextEntities { get; init; }

    /// <summary>Media attached to the option, if available.</summary>
    public PollMedia? Media { get; init; }

    /// <summary>Number of users who chose this option.</summary>
    public required int VoterCount { get; init; }

    /// <summary>User who added the option, if available.</summary>
    public User? AddedByUser { get; init; }

    /// <summary>Chat that added the option, if available.</summary>
    public Chat? AddedByChat { get; init; }

    /// <summary>Date when the option was added, in Unix time, if available.</summary>
    public long? AdditionDate { get; init; }
}
