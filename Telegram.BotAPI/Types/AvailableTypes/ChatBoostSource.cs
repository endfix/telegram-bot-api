using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public abstract class ChatBoostSource
{
    public abstract ChatBoostSources Source { get; }

    public required virtual User User { get; init; }
}

public sealed class ChatBoostSourceGiftCode : ChatBoostSource
{
    public override ChatBoostSources Source => ChatBoostSources.GiftCode;
}

public sealed class ChatBoostSourceGiveaway : ChatBoostSource
{
    public override ChatBoostSources Source => ChatBoostSources.Giveaway;

    public required int GiveawayMessageId { get; init; }

    public int? PrizeStarCount { get; init; }

    public bool? IsUnclaimed { get; init; }
}

public sealed class ChatBoostSourcePremium : ChatBoostSource
{
    public override ChatBoostSources Source => ChatBoostSources.Premium;
}
