using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Base type for a reaction.</summary>
public abstract class ReactionType
{
    /// <summary>Gets the reaction kind.</summary>
    public abstract ReactionTypes Type { get; }
}

/// <summary>Represents a reaction with a custom emoji.</summary>
public sealed class ReactionTypeCustomEmoji : ReactionType
{
    /// <summary>Gets the custom-emoji reaction kind.</summary>
    public override ReactionTypes Type => ReactionTypes.CustomEmoji;

    /// <summary>Identifier of the custom emoji.</summary>
    public required string CustomEmojiId { get; init; }
}

/// <summary>Represents a reaction with a standard emoji.</summary>
public sealed class ReactionTypeEmoji : ReactionType
{
    /// <summary>Gets the standard-emoji reaction kind.</summary>
    public override ReactionTypes Type => ReactionTypes.Emoji;

    /// <summary>Emoji used for the reaction.</summary>
    public required string Emoji { get; init; }
}

/// <summary>Represents a paid reaction.</summary>
public sealed class ReactionTypePaid : ReactionType
{
    /// <summary>Gets the paid reaction kind.</summary>
    public override ReactionTypes Type => ReactionTypes.Paid;
}
