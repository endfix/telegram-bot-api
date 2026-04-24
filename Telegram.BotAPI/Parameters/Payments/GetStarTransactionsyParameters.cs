using Telegram.BotAPI.Protocol;

namespace Telegram.BotAPI.Parameters;

public sealed class GetStarTransactionsyParameters : ApiRequestParameters
{
    public int? Offset { get; init; }

    public int? Limit { get; init; }
}
