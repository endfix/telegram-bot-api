namespace Telegram.BotAPI.Types;

public sealed class PaidMediaPurchased
{
    public User From { get; set; }

    public string PaidMediaPayload { get; set; }
}
