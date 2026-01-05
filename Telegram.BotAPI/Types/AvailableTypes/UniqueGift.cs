namespace Telegram.BotAPI.Types;

public sealed class UniqueGift
{
    public string GiftId { get; set; }

    public string BaseName { get; set; }

    public string Name { get; set; }

    public int Number { get; set; }

    public UniqueGiftModel Model { get; set; }

    public UniqueGiftSymbol Symbol { get; set; }

    public UniqueGiftBackdrop Backdrop { get; set; }

    public bool IsPremium { get; set; }

    public bool IsFromBlockchain { get; set; }

    public UniqueGiftColors Colors { get; set; }

    public Chat PublisherChat { get; set; }
}
