namespace Telegram.BotAPI.Parameters;

public sealed class RefundStarPaymentParameters : ApiRequestParameters
{
    public long UserId { get; set; }

    public string TelegramPaymentChargeId { get; set; }
}
