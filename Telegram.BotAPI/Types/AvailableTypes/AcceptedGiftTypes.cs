namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes the types of gifts that can be gifted to a user or a chat.
/// </summary>
public sealed class AcceptedGiftTypes
{
    /// <summary>
    /// True if unlimited regular gifts are accepted.
    /// </summary>
    public required bool UnlimitedGifts {  get; init; }

    /// <summary>
    /// True if limited regular gifts are accepted.
    /// </summary>
    public required bool LimitedGifts { get; init; }

    /// <summary>
    /// True if unique gifts or gifts that can be upgraded to unique for free are accepted.
    /// </summary>
    public required bool UniqueGifts { get; init; }

    /// <summary>
    /// True if a Telegram Premium subscription is accepted.
    /// </summary>
    public required bool PremiumSubscription { get; init; }

    /// <summary>
    /// True if transfers of unique gifts from channels are accepted.
    /// </summary>
    public required bool GiftsFromChannels { get; init; }
}
