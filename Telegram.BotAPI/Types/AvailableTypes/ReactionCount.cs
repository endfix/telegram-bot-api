namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Contains the count for one reaction type.</summary>
public sealed class ReactionCount
{
    /// <summary>Reaction type.</summary>
    public required ReactionType Type { get; init; }

    /// <summary>Total number of users that used this reaction.</summary>
    public required int TotalCount { get; init; }
}
