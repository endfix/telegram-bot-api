using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public sealed class UniqueGiftModel
{
    public required string Name { get; init; }

    public required Sticker Sticker { get; init; }

    public required int RarityPerMille { get; init; }

    public UniqueGiftModelRarity? Rarity { get; init; }
}
