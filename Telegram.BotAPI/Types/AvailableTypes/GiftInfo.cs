using System.Collections.Generic;

namespace Telegram.BotAPI.Types;

public sealed class GiftInfo
{
    public required Gift Gift { get; init; }

    public string? OwnedGiftId { get; init; }

    public int? ConvertStarCount { get; init; }

    public int? PrepaidUpgradeStarCount { get; init; }

    public bool? IsUpgradeSeparate { get; init; }

    public bool? CanBeUpgraded { get; init; }

    public string? Text { get; init; }

    public IReadOnlyList<MessageEntity>? Entities { get; init; }

    public bool? IsPrivate { get; init; }

    public int? UniqueGiftNumber { get; init; }
}
