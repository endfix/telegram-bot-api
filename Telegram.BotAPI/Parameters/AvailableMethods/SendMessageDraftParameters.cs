using System.Collections.Generic;
using Telegram.BotAPI.Protocol;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class SendMessageDraftParameters : ApiRequestParameters
{
    public required long ChatId { get; init; }

    public int? MessageThreadId { get; init; }

    public required int DraftId { get; init; }

    public string? Text { get; init; }

    public string? ParseMode { get; init; }

    public IReadOnlyList<MessageEntity>? Entities { get; init; }
}
