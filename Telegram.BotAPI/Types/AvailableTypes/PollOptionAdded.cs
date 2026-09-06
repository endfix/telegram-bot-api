using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes a service message about an answer option added to a poll.
/// </summary>
public sealed class PollOptionAdded
{
    /// <summary>Optional message containing the poll to which the option was added, if known.</summary>
    public MaybeInaccessibleMessage? PollMessage { get; init; }

    /// <summary>Unique identifier of the added option.</summary>
    public required string OptionPersistentId { get; init; }

    /// <summary>Option text.</summary>
    public required string OptionText { get; init; }

    /// <summary>Optional special entities that appear in the option text.</summary>
    public IReadOnlyList<MessageEntity>? OptionTextEntities { get; init; }
}
