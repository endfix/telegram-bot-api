namespace Telegram.BotAPI.Types;

public sealed class OwnedGifts
{
    public int TotalCount { get; set; }

    public OwnedGift[] Gifts { get; set; }
    
    public string NextOffset { get; set; }
}
