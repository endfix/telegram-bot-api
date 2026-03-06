using System.Collections.Generic;

namespace Telegram.BotAPI.Types;

public sealed class ReplyParameters
{
    public required long MessageId { get; init; }

    public object? ChatId { get; init; }

    public bool? AllowSendingWithoutReply { get; init; }

    public string? Quote { get; init; } 

    public string? QuoteParseMode { get; init; }

    public IReadOnlyList<MessageEntity>? QuoteEntities { get; init; }

    public int? QuotePosition { get; init; }

    public int? ChecklistTaskId { get; init; }
}
