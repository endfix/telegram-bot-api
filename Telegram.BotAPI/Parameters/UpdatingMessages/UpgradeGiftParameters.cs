namespace Telegram.BotAPI.Parameters;

public sealed class UpgradeGiftParameters : ApiRequestParameters
{
    public string BusinessConnectionId { get; set; }

    public string OwnedGiftId { get; set; }

    public bool KeepOriginalDetails { get; set; }

    public int StarCount { get; set; }
}
