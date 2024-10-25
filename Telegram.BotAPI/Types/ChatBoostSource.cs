namespace Telegram.BotAPI.Types;

// https://core.telegram.org/bots/api#chatboostsource
public abstract class ChatBoostSource
{
    public virtual string Source { get; set; }

    public User User { get; set; }

    public static class Sources
    {
        public const string PREMIUM = "premium";

        public const string GIFT_CODE = "gift_code";

        public const string GIVEAWAY = "giveaway";
    }
}

// https://core.telegram.org/bots/api#chatboostsourcegiftcode
public sealed class ChatBoostSourceGiftCode : ChatBoostSource
{
    public override string Source => Sources.GIFT_CODE;
}

// https://core.telegram.org/bots/api#chatboostsourcegiveaway
public sealed class ChatBoostSourceGiveaway : ChatBoostSource
{
    public override string Source => Sources.GIVEAWAY;

    public int GiveawayMessageId { get; set; }

    public int PrizeStarCount { get; set; }

    public bool IsUnclaimed { get; set; }
}

// https://core.telegram.org/bots/api#chatboostsourcepremium
public sealed class ChatBoostSourcePremium : ChatBoostSource
{
    public override string Source => Sources.PREMIUM;
}
