namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Represents one row of a game high score table.
/// </summary>
public sealed class GameHighScore
{
    /// <summary>Position in the high score table.</summary>
    public required int Position { get; init; }

    /// <summary>User who achieved the score.</summary>
    public required User User { get; init; }

    /// <summary>Score.</summary>
    public required int Score { get; init; }
}
