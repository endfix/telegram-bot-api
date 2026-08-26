namespace Endfix.Telegram.BotAPI.Types;

public sealed class GameHighScore
{
    public required int Position { get; init; }

    public required User User { get; init; }

    public required int Score { get; init; }
}
