using System.Collections.Generic;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class AnswerInlineQueryParameters : ApiRequestParameters
{
    public required string InlineQueryId { get; init; }

    public required IReadOnlyList<InlineQueryResult> Results { get; init; }

    public int? CacheTime { get; init; }

    public bool? IsPersonal { get; init; }

    public string? NextOffset { get; init; }

    public InlineQueryResultsButton? Button { get; init; }
}
