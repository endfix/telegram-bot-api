namespace Telegram.BotAPI.Types;

public sealed class UserRating
{
    public required int Level { get; set; }

    public required int Rating { get; set; }

    public required int CurrentLevelRating { get; set; }

    public int? NextLevelRating { get; set; } = null;
}
