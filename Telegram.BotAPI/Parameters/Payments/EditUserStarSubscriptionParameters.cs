namespace Telegram.BotAPI.Parameters;

public sealed class EditUserStarSubscriptionParameters : ApiRequestParameters
{
    public required long UserId { get; init; }

    public required string TelegramPaymentChargeId { get; init; }

    public required bool IsCanceled { get; init; }
}
