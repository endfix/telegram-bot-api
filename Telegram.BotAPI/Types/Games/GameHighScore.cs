namespace Telegram.BotAPI.Types.Games;

public sealed class GameHighScore
{
    public int Position { get; set; }

    public User User { get; set; }

    public int Score { get; set; }
}
