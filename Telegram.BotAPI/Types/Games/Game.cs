using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Represents a game.
/// </summary>
public sealed class Game
{
    /// <summary>Title of the game.</summary>
    public required string Title { get; init; }

    /// <summary>Description of the game.</summary>
    public required string Description { get; init; }

    /// <summary>Photo that will be displayed in the game message.</summary>
    public required IReadOnlyList<PhotoSize> Photo { get; init; }

    /// <summary>Optional text that is shown with the game.</summary>
    public string? Text { get; init; }

    /// <summary>Optional special entities that appear in the game text.</summary>
    public IReadOnlyList<MessageEntity>? TextEntities { get; init; }

    /// <summary>Optional animation that will be displayed in the game message.</summary>
    public Animation? Animation { get; init; }
}
