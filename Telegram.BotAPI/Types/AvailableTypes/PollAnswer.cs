using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents a user's answer in a non-anonymous poll.</summary>
public sealed class PollAnswer
{
    /// <summary>Unique identifier of the poll.</summary>
    public required string PollId { get; init; }

    /// <summary>Chat where the poll was answered, if the answer was sent on behalf of a chat.</summary>
    public Chat? VoterChat { get; init; }

    /// <summary>User who changed the answer, if available.</summary>
    public User? User { get; init; }

    /// <summary>Identifiers of the selected options.</summary>
    public required IReadOnlyList<int> OptionIds { get; init; }

    /// <summary>Persistent identifiers of the selected options.</summary>
    public required IReadOnlyList<string> OptionPersistentIds { get; init; }
}
