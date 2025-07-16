namespace Telegram.BotAPI.Types;

public sealed class StarTransaction
{
    public string Id { get; set; }

    public int Amount { get; set; }

    public int NanostarAmount { get; set; }

    public int Date { get; set; }

    public TransactionPartner Source { get; set; }

    public TransactionPartner Receiver { get; set; }
}
