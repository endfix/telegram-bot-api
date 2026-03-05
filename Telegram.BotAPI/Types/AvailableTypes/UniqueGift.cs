namespace Telegram.BotAPI.Types;

public sealed class UniqueGift
{
    public required string GiftId { get; set; }

    public required string BaseName { get; set; }

    public required string Name { get; set; }

    public required int Number { get; set; }

    public required UniqueGiftModel Model { get; set; }

    public required UniqueGiftSymbol Symbol { get; set; }

    public required UniqueGiftBackdrop Backdrop { get; set; }

    public bool? IsPremium { get; set; }

    public bool? IsBurned { get; set; }

    public bool? IsFromBlockchain { get; set; }

    public UniqueGiftColors? Colors { get; set; }

    public Chat? PublisherChat { get; set; }
}
