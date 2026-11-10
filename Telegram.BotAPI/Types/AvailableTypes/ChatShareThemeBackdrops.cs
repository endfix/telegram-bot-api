using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Contains the backdrops available for chat share themes.</summary>
public sealed class ChatShareThemeBackdrops
{
    /// <summary>The available backdrops.</summary>
    public required IReadOnlyList<ChatShareThemeBackdrop> Backdrops { get; init; }
}
