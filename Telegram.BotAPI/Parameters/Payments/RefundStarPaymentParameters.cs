namespace Telegram.BotAPI.Parameters;

public sealed class RefundStarPaymentParameters : ApiRequestParameters
{
    public required long UserId { get; init; }

    public required string TelegramPaymentChargeId { get; init; }
}
