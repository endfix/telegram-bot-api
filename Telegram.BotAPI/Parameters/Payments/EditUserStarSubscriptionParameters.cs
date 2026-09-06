using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>editUserStarSubscription</c> method.
/// </summary>
public sealed class EditUserStarSubscriptionParameters : ApiRequestParameters
{
    public required long UserId { get; init; }

    public required string TelegramPaymentChargeId { get; init; }

    public required bool IsCanceled { get; init; }
}
