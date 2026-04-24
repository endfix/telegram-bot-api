using Telegram.BotAPI.Protocol;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class AnswerWebAppQueryParameters : ApiRequestParameters
{
    public required string WebAppQueryId { get; init; }

    public required InlineQueryResult Result { get; init; }
}
