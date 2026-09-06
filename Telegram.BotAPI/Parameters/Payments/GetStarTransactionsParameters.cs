using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>getStarTransactions</c> method.
/// </summary>
public sealed class GetStarTransactionsParameters : ApiRequestParameters
{
    public int? Offset { get; init; }

    public int? Limit { get; init; }
}
