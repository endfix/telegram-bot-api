namespace Telegram.BotAPI.Types;

// https://core.telegram.org/bots/api#reactiontype
public abstract class ReactionType
{
    public virtual string Type { get; set; }

    public static class Types
    {
        public const string EMOJI = "emoji";

        public const string CUSTOM_EMOJI = "custom_emoji";

        public const string PAID = "paid";
    }
}

// https://core.telegram.org/bots/api#reactiontypecustomemoji
public sealed class ReactionTypeCustomEmoji : ReactionType
{
    public override string Type => Types.CUSTOM_EMOJI;

    public string CustomEmojiId { get; set; }
}

// https://core.telegram.org/bots/api#reactiontypeemoji
public sealed class ReactionTypeEmoji : ReactionType
{
    public override string Type => Types.EMOJI;

    public string Emoji { get; set; }
}

// https://core.telegram.org/bots/api#reactiontypepaid
public sealed class ReactionTypePaid : ReactionType
{
    public override string Type => Types.PAID;
}
