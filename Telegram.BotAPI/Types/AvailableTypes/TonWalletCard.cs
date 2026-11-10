using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes a TON wallet card, which is shown on the profile page of a user to everyone.
/// </summary>
public sealed class TonWalletCard
{
    /// <summary>Address of the wallet.</summary>
    public required string Address { get; init; }

    /// <summary>
    /// Balance of the wallet, in the smallest units of the cryptocurrency, as a decimal number.
    /// </summary>
    public required string Amount { get; init; }

    /// <summary>Stickers placed on the card.</summary>
    public required IReadOnlyList<TonWalletCardSticker> Stickers { get; init; }

    /// <summary>
    /// Address of the NFT of one of the stickers whose colors must be used for the card
    /// background; omitted if the default background must be used.
    /// </summary>
    public string? BackgroundNftAddress { get; init; }
}
