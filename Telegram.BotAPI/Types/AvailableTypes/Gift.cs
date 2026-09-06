namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents a gift that can be sent by the bot.</summary>
public sealed class Gift
{
    /// <summary>Unique identifier of the gift.</summary>
    public required string Id { get; init; }

    /// <summary>Sticker that represents the gift.</summary>
    public required Sticker Sticker { get; init; }

    /// <summary>Number of Telegram Stars that must be paid to send the gift.</summary>
    public required int StarCount { get; init; }

    /// <summary>Optional. Number of Telegram Stars required to upgrade the gift to a unique one.</summary>
    public int? UpgradeStarCount { get; init; }

    /// <summary>Optional. Indicates that the gift can only be purchased by Telegram Premium subscribers.</summary>
    public bool? IsPremium { get; init; }

    /// <summary>Optional. Indicates that the gift can be used to customize a user's appearance after being upgraded.</summary>
    public bool? HasColors { get; init; }

    /// <summary>Optional. Total number of gifts of this type that can be sent by all users.</summary>
    public int? TotalCount { get; init; }

    /// <summary>Optional. Number of remaining gifts of this type that can be sent by all users.</summary>
    public int? RemainingCount { get; init; }

    /// <summary>Optional. Total number of gifts of this type that can be sent by the bot.</summary>
    public int? PersonalTotalCount { get; init; }

    /// <summary>Optional. Number of remaining gifts of this type that can be sent by the bot.</summary>
    public int? PersonalRemainingCount { get; init; }

    /// <summary>Optional. Background of the gift.</summary>
    public GiftBackground? Background { get; init; }

    /// <summary>Optional. Total number of different unique gifts that can be obtained by upgrading this gift.</summary>
    public int? UniqueGiftVariantCount { get; init; }

    /// <summary>Optional. Chat that published the gift.</summary>
    public Chat? PublisherChat { get; init; }
}
