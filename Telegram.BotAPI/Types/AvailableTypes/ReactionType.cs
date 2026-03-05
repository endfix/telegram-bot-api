using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public abstract class ReactionType
{
    public abstract ReactionTypes Type { get; }
}

public sealed class ReactionTypeCustomEmoji : ReactionType
{
    public override ReactionTypes Type => ReactionTypes.CustomEmoji;

    public required string CustomEmojiId { get; init; }
}

public sealed class ReactionTypeEmoji : ReactionType
{
    public override ReactionTypes Type => ReactionTypes.Emoji;

    public required string Emoji { get; init; }
}

public sealed class ReactionTypePaid : ReactionType
{
    public override ReactionTypes Type => ReactionTypes.Paid;
}
