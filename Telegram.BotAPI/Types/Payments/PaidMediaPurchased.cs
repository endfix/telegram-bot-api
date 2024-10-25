namespace Telegram.BotAPI.Types.Payments;

// https://core.telegram.org/bots/api#paidmediapurchased
public sealed class PaidMediaPurchased
{
    public User From { get; set; }

    public string PaidMediaPayload { get; set; }
}
