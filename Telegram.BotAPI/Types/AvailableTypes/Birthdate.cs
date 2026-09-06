namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes the birthdate of a user.
/// </summary>
public sealed class Birthdate
{
    /// <summary>Day of the user's birth; 1-31.</summary>
    public required int Day { get; init; }

    /// <summary>Month of the user's birth; 1-12.</summary>
    public required int Month { get; init; }

    /// <summary>Optional year of the user's birth.</summary>
    public int? Year { get; init; }
}
