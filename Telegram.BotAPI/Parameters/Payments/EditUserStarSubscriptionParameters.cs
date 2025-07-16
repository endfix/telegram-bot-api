namespace Telegram.BotAPI.Parameters;

public sealed class EditUserStarSubscriptionParameters : ApiRequestParameters
{
    public long UserId { get; set; }

    public string TelegramPaymentChargeId { get; set; }

    public bool IsCanceled { get; set; }
}
