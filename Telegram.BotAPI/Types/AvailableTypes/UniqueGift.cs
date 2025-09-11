namespace Telegram.BotAPI.Types;

public sealed class UniqueGift
{
    public string BaseName { get; set; }

    public string Name { get; set; }

    public int Number { get; set; }

    public UniqueGiftModel Model { get; set; }

    public UniqueGiftSymbol Symbol { get; set; }

    public UniqueGiftBackdrop Backdrop { get; set; }

    public Chat PublisherChat { get; set; }
}
