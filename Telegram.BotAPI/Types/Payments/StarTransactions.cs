using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

public sealed class StarTransactions
{
    public required IReadOnlyList<StarTransaction> Transactions { get; init; }
}
