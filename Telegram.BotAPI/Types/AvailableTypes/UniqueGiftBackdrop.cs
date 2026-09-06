namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes the backdrop of a unique gift.
/// </summary>
public sealed class UniqueGiftBackdrop
{
    /// <summary>Name of the backdrop.</summary>
    public required string Name { get; init; }

    /// <summary>Colors of the backdrop.</summary>
    public required UniqueGiftBackdropColors Colors { get; init; }

    /// <summary>The number of unique gifts that receive this backdrop for every 1000 gifts upgraded.</summary>
    public required int RarityPerMille { get; init; }
}
