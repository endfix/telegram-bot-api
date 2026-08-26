using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

public sealed class UniqueGiftInfo
{
    public required UniqueGift Gift { get; init; }

    public required UniqueGiftInfoOrigin Origin { get; init; }

    public string? Text { get; init; }

    public IReadOnlyList<MessageEntity>? Entities { get; init; }

    public bool? IsPrivate { get; init; }

    public string? LastResaleCurrency { get; init; }

    public int? LastResaleAmount { get; init; }

    public string? OwnedGiftId { get; init; }

    public int? TransferStarCount { get; init; }

    public int? NextTransferDate { get; init; }
}
