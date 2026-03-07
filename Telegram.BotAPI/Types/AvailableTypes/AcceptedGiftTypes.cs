namespace Telegram.BotAPI.Types;

public sealed class AcceptedGiftTypes
{
    public required bool UnlimitedGifts {  get; init; }

    public required bool LimitedGifts { get; init; }

    public required bool UniqueGifts { get; init; }

    public required bool GiftsFromChannels { get; init; }
}
