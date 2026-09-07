namespace Endfix.Telegram.BotAPI.Enums;

/// <summary>Identifies the operation that produced unique-gift information.</summary>
public enum UniqueGiftInfoOrigin
{
    /// <summary>A regular gift was upgraded to a unique gift.</summary>
    Upgrade,

    /// <summary>A unique gift was transferred.</summary>
    Transfer,

    /// <summary>A unique gift was purchased through resale.</summary>
    Resale,

    /// <summary>An upgrade was gifted to the recipient.</summary>
    GiftedUpgrade,

    /// <summary>The unique gift was involved in an offer.</summary>
    Offer
}
