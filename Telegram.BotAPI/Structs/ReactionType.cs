namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#reactiontype
    public abstract class ReactionType
    {
        public virtual string Type { get; set; }

        public class Types
        {
            public const string EMOJI = "emoji";

            public const string CUSTOM_EMOJI = "custom_emoji";

            public const string PAID = "paid";
        }

        // https://core.telegram.org/bots/api#reactiontypeemoji
        public class EmojiStruct : ReactionType
        {
            public override string Type => Types.EMOJI;

            public string Emoji { get; set; }
        }

        // https://core.telegram.org/bots/api#reactiontypecustomemoji
        public class CustomEmojiStruct : ReactionType
        {
            public override string Type => Types.CUSTOM_EMOJI;

            public string CustomEmojiId { get; set; }
        }

        // https://core.telegram.org/bots/api#reactiontypepaid
        public class PaidStruct : ReactionType
        {
            public override string Type => Types.PAID;
        }
    }
}
