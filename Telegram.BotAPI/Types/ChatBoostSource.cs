namespace Telegram.BotAPI.Types;

public abstract class ChatBoostSource
{
    public abstract string Source { get; }

    public User User { get; set; }

    public static class Sources
    {
        public const string PREMIUM = "premium";

        public const string GIFT_CODE = "gift_code";

        public const string GIVEAWAY = "giveaway";
    }
}

public sealed class ChatBoostSourceGiftCode : ChatBoostSource
{
    public override string Source => Sources.GIFT_CODE;
}

public sealed class ChatBoostSourceGiveaway : ChatBoostSource
{
    public override string Source => Sources.GIVEAWAY;

    public int GiveawayMessageId { get; set; }

    public int PrizeStarCount { get; set; }

    public bool IsUnclaimed { get; set; }
}

public sealed class ChatBoostSourcePremium : ChatBoostSource
{
    public override string Source => Sources.PREMIUM;
}
