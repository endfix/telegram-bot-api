using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes a service message about an answer option deleted from a poll.
/// </summary>
public sealed class PollOptionDeleted
{
    /// <summary>Optional message containing the poll from which the option was deleted, if known.</summary>
    public MaybeInaccessibleMessage? PollMessage { get; init; }

    /// <summary>Unique identifier of the deleted option.</summary>
    public required string OptionPersistentId { get; init; }

    /// <summary>Option text.</summary>
    public required string OptionText { get; init; }

    /// <summary>Optional special entities that appear in the option text.</summary>
    public IReadOnlyList<MessageEntity>? OptionTextEntities { get; init; }
}
