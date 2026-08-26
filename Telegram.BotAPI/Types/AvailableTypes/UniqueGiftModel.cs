using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

public sealed class UniqueGiftModel
{
    public required string Name { get; init; }

    public required Sticker Sticker { get; init; }

    public required int RarityPerMille { get; init; }

    public UniqueGiftModelRarity? Rarity { get; init; }
}
