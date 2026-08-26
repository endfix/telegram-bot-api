using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

public abstract class ChatBoostSource
{
    public abstract ChatBoostSources Source { get; }
}

public sealed class ChatBoostSourceGiftCode : ChatBoostSource
{
    public override ChatBoostSources Source => ChatBoostSources.GiftCode;

    public required User User { get; init; }
}

public sealed class ChatBoostSourceGiveaway : ChatBoostSource
{
    public override ChatBoostSources Source => ChatBoostSources.Giveaway;

    public required long GiveawayMessageId { get; init; }

    public User? User { get; init; }

    public int? PrizeStarCount { get; init; }

    public bool? IsUnclaimed { get; init; }
}

public sealed class ChatBoostSourcePremium : ChatBoostSource
{
    public override ChatBoostSources Source => ChatBoostSources.Premium;

    public required User User { get; init; }
}
