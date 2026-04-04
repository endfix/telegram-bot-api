using System.Collections.Generic;
using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public abstract class OwnedGift
{
    public abstract OwnedGiftType Type { get; }
}

public sealed class OwnedGiftRegular : OwnedGift
{
    public override OwnedGiftType Type => OwnedGiftType.Regular;

    public required Gift Gift { get; init; }

    public string? OwnedGiftId { get; init; }

    public User? SenderUser { get; init; }

    public required int SendDate { get; init; }

    public string? Text { get; init; }

    public IReadOnlyList<MessageEntity>? Entities { get; init; }

    public bool? IsPrivate { get; init; }

    public bool? IsSaved { get; init; }

    public bool? CanBeUpgraded { get; init; }

    public bool? WasRefunded { get; init; }

    public int? ConvertStarCount { get; init; }

    public int? PrepaidUpgradeStarCount { get; init; }

    public bool? IsUpgradeSeparate { get; init; }

    public int? UniqueGiftNumber { get; init; }
}

public sealed class OwnedGiftUnique : OwnedGift
{
    public override OwnedGiftType Type => OwnedGiftType.Unique;

    public required UniqueGift Gift { get; init; }

    public string? OwnedGiftId { get; init; }

    public User? SenderUser { get; init; }

    public int? SendDate { get; init; }

    public bool? IsSaved { get; init; }

    public bool? CanBeTransferred { get; init; }

    public int? TransferStarCount { get; init; }

    public int? NextTransferDate { get; init; }
}
