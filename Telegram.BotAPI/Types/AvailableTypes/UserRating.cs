namespace Endfix.Telegram.BotAPI.Types;

public sealed class UserRating
{
    public required int Level { get; init; }

    public required int Rating { get; init; }

    public required int CurrentLevelRating { get; init; }

    public int? NextLevelRating { get; init; }
}
