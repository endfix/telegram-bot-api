using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents an NFT in the TON blockchain.</summary>
public sealed class TonNft
{
    /// <summary>Address of the NFT.</summary>
    public required string Address { get; init; }

    /// <summary>Address of the collection to which the NFT belongs; omitted if unknown.</summary>
    public string? CollectionAddress { get; init; }

    /// <summary>
    /// Index of the NFT among all NFTs from the collection, as a decimal number.
    /// </summary>
    public required string Index { get; init; }

    /// <summary>Name of the NFT.</summary>
    public required string Name { get; init; }

    /// <summary>Description of the NFT.</summary>
    public required string Description { get; init; }

    /// <summary>Attributes of the NFT.</summary>
    public IReadOnlyList<TonNftAttribute>? Attributes { get; init; }

    /// <summary>The unique gift corresponding to the NFT.</summary>
    public UniqueGift? Gift { get; init; }
}
