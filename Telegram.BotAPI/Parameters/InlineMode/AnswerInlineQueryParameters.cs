using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>answerInlineQuery</c> method.
/// </summary>
public sealed class AnswerInlineQueryParameters : ApiRequestParameters
{
    /// <summary>Unique identifier of the answered inline query.</summary>
    public required string InlineQueryId { get; init; }

    /// <summary>Results for the inline query. No more than 50 results can be returned.</summary>
    public required IReadOnlyList<InlineQueryResult> Results { get; init; }

    /// <summary>Maximum server-side caching time in seconds. The default is 300.</summary>
    public int? CacheTime { get; init; }

    /// <summary>Whether results may be cached only for the user who sent the query.</summary>
    public bool? IsPersonal { get; init; }

    /// <summary>Offset for the next page. Its length must not exceed 64 bytes.</summary>
    public string? NextOffset { get; init; }

    /// <summary>Optional button shown above the inline results.</summary>
    public InlineQueryResultsButton? Button { get; init; }
}
