using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public sealed class UniqueGiftModel
{
    public required string Name { get; set; }

    public required Sticker Sticker { get; set; }

    public required int RarityPerMille { get; set; }

    public UniqueGiftModelRarities? Rarity { get; set; } = null;
}
