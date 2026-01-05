namespace Telegram.BotAPI.Types;

public sealed class GiftInfo
{
    public Gift Gift { get; set; }

    public string OwnedGiftId { get; set; }

    public int ConvertStarCount { get; set; }

    public int PrepaidUpgradeStarCount { get; set; }

    public bool IsUpgradeSeparate { get; set; }

    public bool CanBeUpgraded { get; set; }

    public string Text { get; set; }

    public MessageEntity[] Entities { get; set; }

    public bool IsPrivate { get; set; }

    public int UniqueGiftNumber { get; set; }
}
