namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes a unique gift that was upgraded from a regular gift.
/// </summary>
public sealed class UniqueGift
{
    /// <summary>Identifier of the regular gift from which the gift was upgraded.</summary>
    public required string GiftId { get; init; }

    /// <summary>Human-readable name of the regular gift from which this unique gift was upgraded.</summary>
    public required string BaseName { get; init; }

    /// <summary>Unique name of the gift, usable in t.me/nft links and story areas.</summary>
    public required string Name { get; init; }

    /// <summary>Unique number of the upgraded gift among gifts upgraded from the same regular gift.</summary>
    public required int Number { get; init; }

    /// <summary>Model of the gift.</summary>
    public required UniqueGiftModel Model { get; init; }

    /// <summary>Symbol of the gift.</summary>
    public required UniqueGiftSymbol Symbol { get; init; }

    /// <summary>Backdrop of the gift.</summary>
    public required UniqueGiftBackdrop Backdrop { get; init; }

    /// <summary>True if the original regular gift was exclusively purchasable by Telegram Premium subscribers.</summary>
    public bool? IsPremium { get; init; }

    /// <summary>True if the gift was used to craft another gift and is no longer available.</summary>
    public bool? IsBurned { get; init; }

    /// <summary>True if the gift is assigned from the TON blockchain and cannot be resold or transferred in Telegram.</summary>
    public bool? IsFromBlockchain { get; init; }

    /// <summary>Optional color scheme available to the gift's owner for the chat's name, replies and link previews.</summary>
    public UniqueGiftColors? Colors { get; init; }

    /// <summary>Optional information about the chat that published the gift.</summary>
    public Chat? PublisherChat { get; init; }
}
