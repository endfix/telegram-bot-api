using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>upgradeGift</c> method.
/// </summary>
public sealed class UpgradeGiftParameters : ApiRequestParameters
{
    /// <summary>Identifier of the business connection.</summary>
    public required string BusinessConnectionId { get; init; }

    /// <summary>Identifier of the regular gift to upgrade.</summary>
    public required string OwnedGiftId { get; init; }

    /// <summary>Whether to preserve the original text, sender and receiver.</summary>
    public bool? KeepOriginalDetails { get; init; }

    /// <summary>Stars paid from the business account. Pass 0 when the gift has a prepaid upgrade; otherwise pass the required upgrade price.</summary>
    public int? StarCount { get; init; }
}
