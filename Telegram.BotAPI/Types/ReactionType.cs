namespace Telegram.BotAPI.Types;

public abstract class ReactionType
{
    public abstract string Type { get; }

    public static class Types
    {
        public const string EMOJI = "emoji";

        public const string CUSTOM_EMOJI = "custom_emoji";

        public const string PAID = "paid";
    }
}

public sealed class ReactionTypeCustomEmoji : ReactionType
{
    public override string Type => Types.CUSTOM_EMOJI;

    public string CustomEmojiId { get; set; }
}

public sealed class ReactionTypeEmoji : ReactionType
{
    public override string Type => Types.EMOJI;

    public string Emoji { get; set; }
}

public sealed class ReactionTypePaid : ReactionType
{
    public override string Type => Types.PAID;
}
