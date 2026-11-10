namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes a TON wallet of the user, which is used in a query from a widget.
/// </summary>
public sealed class WidgetQueryWallet
{
    /// <summary>Address of the wallet.</summary>
    public required string Address { get; init; }

    /// <summary>
    /// Balance of the wallet, in the smallest units of the cryptocurrency, as a decimal number.
    /// </summary>
    public required string Amount { get; init; }

    /// <summary>Hex-encoded public key of the wallet; omitted if unknown.</summary>
    public string? PublicKey { get; init; }

    /// <summary>
    /// Base64-encoded serialized <c>StateInit</c> of the wallet contract; omitted if and only if
    /// <see cref="PublicKey"/> is omitted.
    /// </summary>
    public string? StateInit { get; init; }
}
