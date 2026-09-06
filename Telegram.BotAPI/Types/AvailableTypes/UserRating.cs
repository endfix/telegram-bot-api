namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes the rating of a user based on their Telegram Star spendings.
/// </summary>
public sealed class UserRating
{
    /// <summary>Current level of the user, indicating their reliability when purchasing digital goods and services.</summary>
    public required int Level { get; init; }

    /// <summary>Numerical value of the user's rating; the higher the rating, the better.</summary>
    public required int Rating { get; init; }

    /// <summary>The rating value required to get the current level.</summary>
    public required int CurrentLevelRating { get; init; }

    /// <summary>Optional rating value required to get to the next level; omitted if the maximum level was reached.</summary>
    public int? NextLevelRating { get; init; }
}
