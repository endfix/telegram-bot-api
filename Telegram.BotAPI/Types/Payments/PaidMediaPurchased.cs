using Telegram.BotAPI.Types.AvailableTypes;

namespace Telegram.BotAPI.Types.Payments;

/// <summary>
/// This object contains information about a paid media purchase.
/// </summary>
public sealed class PaidMediaPurchased
{
    /// <summary>
    /// User who purchased the media
    /// </summary>
    public User From { get; set; }

    /// <summary>
    /// Bot-specified paid media payload
    /// </summary>
    public string PaidMediaPayload { get; set; }
}
