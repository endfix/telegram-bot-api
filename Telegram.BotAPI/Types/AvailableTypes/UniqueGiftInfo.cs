using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Contains information about a unique gift.</summary>
public sealed class UniqueGiftInfo
{
    /// <summary>Unique gift details.</summary>
    public required UniqueGift Gift { get; init; }

    /// <summary>Origin of the unique gift.</summary>
    public required UniqueGiftInfoOrigin Origin { get; init; }

    /// <summary>Text associated with the gift, if available.</summary>
    public string? Text { get; init; }

    /// <summary>Entities in the gift text, if available.</summary>
    public IReadOnlyList<MessageEntity>? Entities { get; init; }

    /// <summary>Indicates whether the gift is private.</summary>
    public bool? IsPrivate { get; init; }

    /// <summary>Currency used for the last resale, if available.</summary>
    public string? LastResaleCurrency { get; init; }

    /// <summary>Amount of the last resale in the smallest units of the currency, if available.</summary>
    public int? LastResaleAmount { get; init; }

    /// <summary>Identifier of the owned gift, if available.</summary>
    public string? OwnedGiftId { get; init; }

    /// <summary>Number of Telegram Stars required to transfer the gift, if applicable.</summary>
    public int? TransferStarCount { get; init; }

    /// <summary>Next transfer date in Unix time, if available.</summary>
    public int? NextTransferDate { get; init; }
}
