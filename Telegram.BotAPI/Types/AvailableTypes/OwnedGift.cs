using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Base type for a gift received and owned by a user or a chat.</summary>
public abstract class OwnedGift
{
    /// <summary>Gets the owned gift type.</summary>
    public abstract OwnedGiftType Type { get; }
}

/// <summary>Describes a regular gift owned by a user or a chat.</summary>
public sealed class OwnedGiftRegular : OwnedGift
{
    public override OwnedGiftType Type => OwnedGiftType.Regular;

    /// <summary>Information about the regular gift.</summary>
    public required Gift Gift { get; init; }

    /// <summary>Optional. Unique identifier of the received gift for the bot; present only for business-account gifts.</summary>
    public string? OwnedGiftId { get; init; }

    /// <summary>Optional. Sender of the gift if known.</summary>
    public User? SenderUser { get; init; }

    /// <summary>Date when the gift was sent, in Unix time.</summary>
    public required int SendDate { get; init; }

    /// <summary>Optional. Text added to the gift.</summary>
    public string? Text { get; init; }

    /// <summary>Optional. Special entities in the gift text.</summary>
    public IReadOnlyList<MessageEntity>? Entities { get; init; }

    /// <summary>Optional. Indicates that the sender and gift text are visible only to the receiver.</summary>
    public bool? IsPrivate { get; init; }

    /// <summary>Optional. Indicates that the gift is displayed on the account profile; business-account gifts only.</summary>
    public bool? IsSaved { get; init; }

    /// <summary>Optional. Indicates that the gift can be upgraded to a unique gift; business-account gifts only.</summary>
    public bool? CanBeUpgraded { get; init; }

    /// <summary>Optional. Indicates that the gift was refunded and is no longer available.</summary>
    public bool? WasRefunded { get; init; }

    /// <summary>Optional. Number of Telegram Stars the receiver can claim instead of the gift.</summary>
    public int? ConvertStarCount { get; init; }

    /// <summary>Optional. Number of Telegram Stars prepaid for the ability to upgrade the gift.</summary>
    public int? PrepaidUpgradeStarCount { get; init; }

    /// <summary>Optional. Indicates that the gift upgrade was purchased after the gift was sent.</summary>
    public bool? IsUpgradeSeparate { get; init; }

    /// <summary>Optional. Unique number reserved for this gift when upgraded.</summary>
    public int? UniqueGiftNumber { get; init; }
}

/// <summary>Describes a unique gift received and owned by a user or a chat.</summary>
public sealed class OwnedGiftUnique : OwnedGift
{
    public override OwnedGiftType Type => OwnedGiftType.Unique;

    /// <summary>Information about the unique gift.</summary>
    public required UniqueGift Gift { get; init; }

    /// <summary>Optional. Unique identifier of the received gift for the bot; present only for business-account gifts.</summary>
    public string? OwnedGiftId { get; init; }

    /// <summary>Optional. Sender of the gift if known.</summary>
    public User? SenderUser { get; init; }

    /// <summary>Date when the gift was sent, in Unix time.</summary>
    public required int SendDate { get; init; }

    /// <summary>Optional. Indicates that the gift is displayed on the account profile; business-account gifts only.</summary>
    public bool? IsSaved { get; init; }

    /// <summary>Optional. Indicates that the gift can be transferred to another owner; business-account gifts only.</summary>
    public bool? CanBeTransferred { get; init; }

    /// <summary>Optional. Number of Telegram Stars required to transfer the gift.</summary>
    public int? TransferStarCount { get; init; }

    /// <summary>Optional. Unix time when the gift can be transferred.</summary>
    public int? NextTransferDate { get; init; }
}
