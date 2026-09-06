using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Base type for a chat boost source.</summary>
public abstract class ChatBoostSource
{
    /// <summary>Gets the boost source kind.</summary>
    public abstract ChatBoostSources Source { get; }
}

/// <summary>Describes a boost obtained from a Telegram Premium gift code.</summary>
public sealed class ChatBoostSourceGiftCode : ChatBoostSource
{
    /// <summary>Gets the gift-code source kind.</summary>
    public override ChatBoostSources Source => ChatBoostSources.GiftCode;

    /// <summary>User who purchased the gift code.</summary>
    public required User User { get; init; }
}

/// <summary>Describes a boost obtained from a giveaway.</summary>
public sealed class ChatBoostSourceGiveaway : ChatBoostSource
{
    /// <summary>Gets the giveaway source kind.</summary>
    public override ChatBoostSources Source => ChatBoostSources.Giveaway;

    /// <summary>Identifier of the giveaway message.</summary>
    public required long GiveawayMessageId { get; init; }

    /// <summary>User who won the giveaway, if available.</summary>
    public User? User { get; init; }

    /// <summary>Number of Telegram Stars included in the prize, if available.</summary>
    public int? PrizeStarCount { get; init; }

    /// <summary>Indicates whether the prize was not claimed.</summary>
    public bool? IsUnclaimed { get; init; }
}

/// <summary>Describes a boost granted by a Telegram Premium subscription.</summary>
public sealed class ChatBoostSourcePremium : ChatBoostSource
{
    /// <summary>Gets the Premium source kind.</summary>
    public override ChatBoostSources Source => ChatBoostSources.Premium;

    /// <summary>User who granted the boost.</summary>
    public required User User { get; init; }
}
