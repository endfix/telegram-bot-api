using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public abstract class ChatBoostSource
{
    public abstract ChatBoostSources Source { get; }

    public User User { get; set; }
}

public sealed class ChatBoostSourceGiftCode : ChatBoostSource
{
    public override ChatBoostSources Source => ChatBoostSources.GiftCode;
}

public sealed class ChatBoostSourceGiveaway : ChatBoostSource
{
    public override ChatBoostSources Source => ChatBoostSources.Giveaway;

    public int GiveawayMessageId { get; set; }

    public int PrizeStarCount { get; set; }

    public bool IsUnclaimed { get; set; }
}

public sealed class ChatBoostSourcePremium : ChatBoostSource
{
    public override ChatBoostSources Source => ChatBoostSources.Premium;
}
