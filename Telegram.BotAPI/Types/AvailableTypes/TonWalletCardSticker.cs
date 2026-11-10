namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes a sticker on a TON wallet card.</summary>
public sealed class TonWalletCardSticker
{
    /// <summary>Position of the sticker on the card.</summary>
    public required AreaPosition Position { get; init; }

    /// <summary>The NFT shown as the sticker.</summary>
    public required TonNft Nft { get; init; }
}
