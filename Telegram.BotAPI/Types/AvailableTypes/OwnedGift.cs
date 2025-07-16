using System;
using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public abstract class OwnedGift
{
    public abstract OwnedGiftTypes Type { get; }
}

public sealed class OwnedGiftRegular : OwnedGift
{
    public override OwnedGiftTypes Type => OwnedGiftTypes.Regular;

    public Gift Gift { get; set; }

    public string OwnedGiftId { get; set; }

    public User SenderUser { get; set; }

    public int SendDate { get; set; }

    public string Text { get; set; }

    public MessageEntity[] Entities { get; set; }

    public bool IsPrivate { get; set; }

    public bool IsSaved { get; set; }

    public bool CanBeUpgraded { get; set; }

    public bool WasRefunded { get; set; }

    public int ConvertStarCount { get; set; }

    public int PrepaidUpgradeStarCount { get; set; }
}

public sealed class OwnedGiftUnique : OwnedGift
{
    public override OwnedGiftTypes Type => OwnedGiftTypes.Unique;

    public UniqueGift Gift { get; set; }

    public string OwnedGiftId { get; set; }

    public User SenderUser { set; get; }

    public int SendDate { set; get; }

    public bool IsSaved { get; set; }

    public bool CanBeTransferred { get; set; }

    public int TransferStarCount { get; set; }

    public int NextTransferDate { set; get; }
}
