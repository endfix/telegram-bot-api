using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class AnswerWebAppQueryParameters : ApiRequestParameters
{
    public string WebAppQueryId { get; set; }

    public InlineQueryResult Result { get; set; }
}
