namespace Telegram.BotAPI.Types;

public sealed class UniqueGift
{
    public required string GiftId { get; init; }

    public required string BaseName { get; init; }

    public required string Name { get; init; }

    public required int Number { get; init; }

    public required UniqueGiftModel Model { get; init; }

    public required UniqueGiftSymbol Symbol { get; init; }

    public required UniqueGiftBackdrop Backdrop { get; init; }

    public bool? IsPremium { get; init; }

    public bool? IsBurned { get; init; }

    public bool? IsFromBlockchain { get; init; }

    public UniqueGiftColors? Colors { get; init; }

    public Chat? PublisherChat { get; init; }
}
