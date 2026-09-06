using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>refundStarPayment</c> method.
/// </summary>
public sealed class RefundStarPaymentParameters : ApiRequestParameters
{
    public required long UserId { get; init; }

    public required string TelegramPaymentChargeId { get; init; }
}
