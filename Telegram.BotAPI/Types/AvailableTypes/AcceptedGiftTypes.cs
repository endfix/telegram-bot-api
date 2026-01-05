namespace Telegram.BotAPI.Types;

public sealed class AcceptedGiftTypes
{
    public bool UnlimitedGifts {  get; set; }

    public bool LimitedGifts { get; set; }

    public bool UniqueGifts { get; set; }

    public bool GiftsFromChannels { get; set; }
}
