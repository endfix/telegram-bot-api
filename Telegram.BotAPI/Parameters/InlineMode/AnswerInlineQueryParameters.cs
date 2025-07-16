using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class AnswerInlineQueryParameters : ApiRequestParameters
{
    public string InlineQueryId { get; set; }

    public InlineQueryResult[] Results { get; set; }

    public int CacheTime { get; set; }

    public bool IsPersonal { get; set; }

    public string NextOffset { get; set; }

    public InlineQueryResultsButton Button { get; set; }
}
