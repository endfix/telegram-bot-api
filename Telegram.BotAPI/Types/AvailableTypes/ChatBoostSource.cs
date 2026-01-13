using System.Text.Json.Serialization;
using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "source")]
[JsonDerivedType(typeof(ChatBoostSourceGiftCode), "gift_code")]
[JsonDerivedType(typeof(ChatBoostSourceGiveaway), "giveaway")]
[JsonDerivedType(typeof(ChatBoostSourcePremium), "premium")]
public abstract class ChatBoostSource
{
    [JsonIgnore]
    public abstract ChatBoostSources Source { get; }

    public required User User { get; init; }
}

public sealed class ChatBoostSourceGiftCode : ChatBoostSource
{
    public override ChatBoostSources Source => ChatBoostSources.GiftCode;
}

public sealed class ChatBoostSourceGiveaway : ChatBoostSource
{
    public override ChatBoostSources Source => ChatBoostSources.Giveaway;

    public required int GiveawayMessageId { get; init; }

    public required int PrizeStarCount { get; init; }

    public required bool IsUnclaimed { get; init; }
}

public sealed class ChatBoostSourcePremium : ChatBoostSource
{
    public override ChatBoostSources Source => ChatBoostSources.Premium;
}
