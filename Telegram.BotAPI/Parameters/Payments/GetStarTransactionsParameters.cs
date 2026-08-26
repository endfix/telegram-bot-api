using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class GetStarTransactionsParameters : ApiRequestParameters
{
    public int? Offset { get; init; }

    public int? Limit { get; init; }
}
