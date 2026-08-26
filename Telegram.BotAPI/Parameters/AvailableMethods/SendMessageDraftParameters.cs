using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class SendMessageDraftParameters : ApiRequestParameters
{
    public required long ChatId { get; init; }

    public long? MessageThreadId { get; init; }

    public required long DraftId { get; init; }

    public string? Text { get; init; }

    public string? ParseMode { get; init; }

    public IReadOnlyList<MessageEntity>? Entities { get; init; }

    public bool? CanStop { get; init; }

    public bool? KeepOnStop { get; init; }
}
