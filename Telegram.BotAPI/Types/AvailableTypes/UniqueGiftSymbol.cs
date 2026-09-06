namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes the symbol shown on the pattern of a unique gift.
/// </summary>
public sealed class UniqueGiftSymbol
{
    /// <summary>Name of the symbol.</summary>
    public required string Name { get; init; }

    /// <summary>The sticker that represents the unique gift.</summary>
    public required Sticker Sticker { get; init; }

    /// <summary>The number of unique gifts that receive this symbol for every 1000 gifts upgraded.</summary>
    public required int RarityPerMille { get; init; }
}
