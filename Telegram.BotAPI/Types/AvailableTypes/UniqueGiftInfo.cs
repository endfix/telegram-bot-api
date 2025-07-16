namespace Telegram.BotAPI.Types;

public sealed class UniqueGiftInfo
{
    public UniqueGift Gift { get; set; }

    public string Origin { get; set; }

    public int LastResaleStarCount { get; set; }

    public string OwnedGiftId { get; set; }

    public int TransferStarCount { get; set; }

    public int NextTransferDate { get; set; }
}
