using Telegram.BotAPI.Types.AvailableTypes;

namespace Telegram.BotAPI.Types.Payments;

public sealed class PaidMediaPurchased
{
    public User From { get; set; }

    public string PaidMediaPayload { get; set; }
}
