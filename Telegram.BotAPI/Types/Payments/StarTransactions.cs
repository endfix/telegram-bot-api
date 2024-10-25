using System.Collections.Generic;

namespace Telegram.BotAPI.Types.Payments;

// https://core.telegram.org/bots/api#startransactions
public sealed class StarTransactions
{
    public List<StarTransaction> Transactions { get; set; }
}
