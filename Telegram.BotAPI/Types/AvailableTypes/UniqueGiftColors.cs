using System.Collections.Generic;

namespace Telegram.BotAPI.Types;

public sealed class UniqueGiftColors
{
    public required string ModelCustomEmojiId { get; init; }

    public required string SymbolCustomEmojiId { get; init; }

    public required int LightThemeMainColor { get; init; }

    public required IReadOnlyList<int> LightThemeOtherColors { get; init; }

    public required int DarkThemeMainColor { get; init; }

    public required IReadOnlyList<int> DarkThemeOtherColors { get; init; }
}
