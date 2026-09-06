using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Contains information about a gift.</summary>
public sealed class GiftInfo
{
    /// <summary>Gift details.</summary>
    public required Gift Gift { get; init; }

    /// <summary>Identifier of the owned gift, if available.</summary>
    public string? OwnedGiftId { get; init; }

    /// <summary>Number of Telegram Stars received when converting the gift, if applicable.</summary>
    public int? ConvertStarCount { get; init; }

    /// <summary>Number of Telegram Stars required for a prepaid upgrade, if applicable.</summary>
    public int? PrepaidUpgradeStarCount { get; init; }

    /// <summary>Indicates whether the upgrade is separate from the gift purchase.</summary>
    public bool? IsUpgradeSeparate { get; init; }

    /// <summary>Indicates whether the gift can be upgraded.</summary>
    public bool? CanBeUpgraded { get; init; }

    /// <summary>Text associated with the gift, if available.</summary>
    public string? Text { get; init; }

    /// <summary>Entities in the gift text, if available.</summary>
    public IReadOnlyList<MessageEntity>? Entities { get; init; }

    /// <summary>Indicates whether the gift is private.</summary>
    public bool? IsPrivate { get; init; }

    /// <summary>Number of the unique gift, if applicable.</summary>
    public int? UniqueGiftNumber { get; init; }
}
