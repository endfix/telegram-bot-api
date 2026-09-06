using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes the model of a unique gift.
/// </summary>
public sealed class UniqueGiftModel
{
    /// <summary>Name of the model.</summary>
    public required string Name { get; init; }

    /// <summary>The sticker that represents the unique gift.</summary>
    public required Sticker Sticker { get; init; }

    /// <summary>The number of unique gifts that receive this model for every 1000 gift upgrades. Always 0 for crafted gifts.</summary>
    public required int RarityPerMille { get; init; }

    /// <summary>Optional rarity of the model if it is a crafted model.</summary>
    public UniqueGiftModelRarity? Rarity { get; init; }
}
