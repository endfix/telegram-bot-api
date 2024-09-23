namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#chatboostsource
    public abstract class ChatBoostSource
    {
        public virtual string Source { get; set; }

        public User User { get; set; }

        public class Types
        {
            public const string PREMIUM = "premium";

            public const string GIFT_CODE = "gift_code";

            public const string GIVEAWAY = "giveaway";
        }

        // https://core.telegram.org/bots/api#chatboostsourcepremium
        public sealed class PremiumStruct : ChatBoostSource
        {
            public override string Source => Types.PREMIUM;
        }

        // https://core.telegram.org/bots/api#chatboostsourcegiftcode
        public sealed class GiftCodeStruct : ChatBoostSource
        {
            public override string Source => Types.GIFT_CODE;
        }

        // https://core.telegram.org/bots/api#chatboostsourcegiveaway
        public sealed class GiveawayStruct : ChatBoostSource
        {
            public override string Source => Types.GIVEAWAY;

            public int GiveawayMessageId { get; set; }

            public int PrizeStarCount { get; set; }

            public bool IsUnclaimed { get; set; }
        }
    }
}
