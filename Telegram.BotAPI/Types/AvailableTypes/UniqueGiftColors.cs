using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Contains the color scheme for a user's name, message replies and link previews based on a unique gift.
/// </summary>
public sealed class UniqueGiftColors
{
    /// <summary>Custom emoji identifier of the unique gift's model.</summary>
    public required string ModelCustomEmojiId { get; init; }

    /// <summary>Custom emoji identifier of the unique gift's symbol.</summary>
    public required string SymbolCustomEmojiId { get; init; }

    /// <summary>Main color used in light themes, in RGB format.</summary>
    public required int LightThemeMainColor { get; init; }

    /// <summary>One to three additional colors used in light themes, in RGB format.</summary>
    public required IReadOnlyList<int> LightThemeOtherColors { get; init; }

    /// <summary>Main color used in dark themes, in RGB format.</summary>
    public required int DarkThemeMainColor { get; init; }

    /// <summary>One to three additional colors used in dark themes, in RGB format.</summary>
    public required IReadOnlyList<int> DarkThemeOtherColors { get; init; }
}
