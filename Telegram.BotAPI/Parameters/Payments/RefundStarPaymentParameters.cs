using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>refundStarPayment</c> method.
/// </summary>
public sealed class RefundStarPaymentParameters : ApiRequestParameters
{
    /// <summary>Identifier of the user whose payment is refunded.</summary>
    public required long UserId { get; init; }

    /// <summary>Telegram payment identifier.</summary>
    public required string TelegramPaymentChargeId { get; init; }
}
