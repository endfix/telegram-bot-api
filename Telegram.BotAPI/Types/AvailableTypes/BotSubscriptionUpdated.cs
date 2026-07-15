using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public sealed class BotSubscriptionUpdated
{
    public required User User { get; init; }

    public required string InvoicePayload { get; init; }

    public BotSubscriptionUpdatedState State { get; init; }
}
