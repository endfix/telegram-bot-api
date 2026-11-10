namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes a service message about a transfer with a TON wallet.</summary>
public sealed class TonWalletTransfer
{
    /// <summary>
    /// Unique identifier of the transaction; may be empty if the transfer has not been sent yet.
    /// </summary>
    public required string TransactionId { get; init; }

    /// <summary>Address of the transfer peer in the TON blockchain.</summary>
    public required string PeerAddress { get; init; }

    /// <summary>
    /// The amount of transferred cryptocurrency, in the smallest units of the cryptocurrency, as
    /// a decimal number; negative for outgoing transfers.
    /// </summary>
    public required string Amount { get; init; }

    /// <summary>
    /// Comment added to the transfer; omitted if the comment is encrypted.
    /// </summary>
    public string? Comment { get; init; }
}
