namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes the colors of the backdrop of a unique gift.
/// </summary>
public sealed class UniqueGiftBackdropColors
{
    /// <summary>The color in the center of the backdrop, in RGB format.</summary>
    public required int CenterColor { get; init; }

    /// <summary>The color on the edges of the backdrop, in RGB format.</summary>
    public required int EdgeColor { get; init; }

    /// <summary>The color applied to the symbol, in RGB format.</summary>
    public required int SymbolColor { get; init; }

    /// <summary>The color used for text on the backdrop, in RGB format.</summary>
    public required int TextColor { get; init; }
}
