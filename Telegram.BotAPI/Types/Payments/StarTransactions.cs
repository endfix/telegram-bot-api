using System.Collections.Generic;

namespace Telegram.BotAPI.Types.Payments;

public sealed class StarTransactions
{
    public List<StarTransaction> Transactions { get; set; }
}
