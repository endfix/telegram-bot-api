namespace Endfix.Telegram.BotAPI.Types;

public sealed class StarTransaction
{
    public required string Id { get; init; }

    public required int Amount { get; init; }

    public int? NanostarAmount { get; init; }

    public int? Date { get; init; }

    public TransactionPartner? Source { get; init; }

    public TransactionPartner? Receiver { get; init; }
}
