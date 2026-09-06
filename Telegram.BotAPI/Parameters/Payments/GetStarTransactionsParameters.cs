using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>getStarTransactions</c> method.
/// </summary>
public sealed class GetStarTransactionsParameters : ApiRequestParameters
{
    /// <summary>Number of transactions to skip in the response.</summary>
    public int? Offset { get; init; }

    /// <summary>Maximum number of transactions to retrieve, from 1 to 100. The default is 100.</summary>
    public int? Limit { get; init; }
}
