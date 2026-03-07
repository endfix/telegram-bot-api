using System.Collections.Generic;

namespace Telegram.BotAPI.Types;

public sealed class StarTransactions
{
    public required IReadOnlyList<StarTransaction> Transactions { get; init; }
}
