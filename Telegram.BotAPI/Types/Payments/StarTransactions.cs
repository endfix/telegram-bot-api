using System.Collections.Generic;

namespace Telegram.BotAPI.Types.Payments;

/// <summary>
/// Contains a list of Telegram Star transactions.
/// </summary>
public sealed class StarTransactions
{
    /// <summary>
    /// The list of transactions
    /// </summary>
    public List<StarTransaction> Transactions { get; set; }
}
