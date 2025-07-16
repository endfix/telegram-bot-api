using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public abstract class ReactionType
{
    public abstract ReactionTypes Type { get; }
}

public sealed class ReactionTypeCustomEmoji : ReactionType
{
    public override ReactionTypes Type => ReactionTypes.CustomEmoji;

    public string CustomEmojiId { get; set; }
}

public sealed class ReactionTypeEmoji : ReactionType
{
    public override ReactionTypes Type => ReactionTypes.Emoji;

    public string Emoji { get; set; }
}

public sealed class ReactionTypePaid : ReactionType
{
    public override ReactionTypes Type => ReactionTypes.Paid;
}
