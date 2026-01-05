using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public sealed class UniqueGiftInfo
{
    public UniqueGift Gift { get; set; }

    public UniqueGiftInfoOrigins Origin { get; set; }

    public string LastResaleCurrency { get; set; }

    public int LastResaleAmount { get; set; }

    public string OwnedGiftId { get; set; }

    public int TransferStarCount { get; set; }

    public int NextTransferDate { get; set; }
}
