namespace Telegram.BotAPI.Types.Payments;

// https://core.telegram.org/bots/api#startransaction
public sealed class StarTransaction
{
    public string Id { get; set; }

    public int Amount { get; set; }

    public int Date { get; set; }

    public TransactionPartner Source { get; set; }

    public TransactionPartner Receiver { get; set; }
}
