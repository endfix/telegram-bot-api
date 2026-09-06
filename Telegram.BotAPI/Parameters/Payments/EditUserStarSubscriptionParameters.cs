using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>editUserStarSubscription</c> method.
/// </summary>
public sealed class EditUserStarSubscriptionParameters : ApiRequestParameters
{
    /// <summary>Identifier of the user whose subscription is edited.</summary>
    public required long UserId { get; init; }

    /// <summary>Telegram payment identifier for the subscription.</summary>
    public required string TelegramPaymentChargeId { get; init; }

    /// <summary>Whether to cancel extension of the subscription.</summary>
    public required bool IsCanceled { get; init; }
}
