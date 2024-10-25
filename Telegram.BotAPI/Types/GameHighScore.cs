namespace Telegram.BotAPI.Types
{
    // https://core.telegram.org/bots/api#gamehighscore
    public sealed class GameHighScore
    {
        public int Position { get; set; }

        public User User { get; set; }

        public int Score { get; set; }
    }
}
