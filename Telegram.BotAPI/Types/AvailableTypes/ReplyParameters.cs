using System.Collections.Generic;

namespace Telegram.BotAPI.Types;

public sealed class ReplyParameters
{
    public long? MessageId { get; init; }

    public ChatIdSource? ChatId { get; init; }

    public long? EphemeralMessageId { get; init; }

    public bool? AllowSendingWithoutReply { get; init; }

    public string? Quote { get; init; } 

    public string? QuoteParseMode { get; init; }

    public IReadOnlyList<MessageEntity>? QuoteEntities { get; init; }

    public int? QuotePosition { get; init; }

    public int? ChecklistTaskId { get; init; }

    public string? PollOptionId { get; init; }
}
