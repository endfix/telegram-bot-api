using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes the message that a new message should reply to.</summary>
public sealed class ReplyParameters
{
    /// <summary>Identifier of the message to reply to in the current chat.</summary>
    public long? MessageId { get; init; }

    /// <summary>Chat containing the message to reply to, if it differs from the current chat.</summary>
    public ChatIdSource? ChatId { get; init; }

    /// <summary>Identifier of an incoming ephemeral message to reply to, if applicable.</summary>
    public long? EphemeralMessageId { get; init; }

    /// <summary>Indicates whether to send the message even if the target message is not found.</summary>
    public bool? AllowSendingWithoutReply { get; init; }

    /// <summary>Quoted part of the message to reply to, if supplied.</summary>
    public string? Quote { get; init; } 

    /// <summary>Parse mode used for entities in the quote, if supplied.</summary>
    public string? QuoteParseMode { get; init; }

    /// <summary>Entities that appear in the quote, if supplied instead of a parse mode.</summary>
    public IReadOnlyList<MessageEntity>? QuoteEntities { get; init; }

    /// <summary>Position of the quote in the original message, in UTF-16 code units.</summary>
    public int? QuotePosition { get; init; }

    /// <summary>Identifier of the checklist task to reply to, if applicable.</summary>
    public int? ChecklistTaskId { get; init; }

    /// <summary>Persistent identifier of the poll option to reply to, if applicable.</summary>
    public string? PollOptionId { get; init; }
}
