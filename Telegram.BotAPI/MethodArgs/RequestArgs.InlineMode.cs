using System.Collections.Generic;
using Telegram.BotAPI.Types.InlineMode;

namespace Telegram.BotAPI.MethodArgs;

public sealed class AnswerInlineQueryArgs : RequestArgs
{
    public string InlineQueryId { get; set; }

    public List<InlineQueryResult> Results { get; set; } = [];
    public int CacheTime { get; set; }

    public bool IsPersonal { get; set; }

    public string NextOffset { get; set; }

    public InlineQueryResultsButton Button { get; set; }
}

public sealed class AnswerWebAppQueryArgs : RequestArgs
{
    public string WebAppQueryId { get; set; }

    public InlineQueryResult Result { get; set; }
}