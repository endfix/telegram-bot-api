namespace Telegram.BotAPI.Types;

public sealed class GameHighScore
{
    public int Position { get; set; }

    public User User { get; set; }

    public int Score { get; set; }
}
