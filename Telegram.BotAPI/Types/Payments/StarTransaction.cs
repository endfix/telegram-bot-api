namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes a transaction involving Telegram Stars.</summary>
public sealed class StarTransaction
{
    /// <summary>Unique identifier of the transaction.</summary>
    public required string Id { get; init; }

    /// <summary>Integer amount of Telegram Stars transferred in the transaction.</summary>
    public required int Amount { get; init; }

    /// <summary>Optional. Number of 1/100000000 shares of Telegram Stars transferred in the transaction.</summary>
    public int? NanostarAmount { get; init; }

    /// <summary>Date when the transaction was created, in Unix time.</summary>
    public required int Date { get; init; }

    /// <summary>Optional. Source of the transaction.</summary>
    public TransactionPartner? Source { get; init; }

    /// <summary>Optional. Receiver of the transaction.</summary>
    public TransactionPartner? Receiver { get; init; }
}
