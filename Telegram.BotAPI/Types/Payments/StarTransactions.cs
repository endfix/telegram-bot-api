using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Contains a list of transactions involving Telegram Stars.</summary>
public sealed class StarTransactions
{
    /// <summary>List of transactions.</summary>
    public required IReadOnlyList<StarTransaction> Transactions { get; init; }
}
