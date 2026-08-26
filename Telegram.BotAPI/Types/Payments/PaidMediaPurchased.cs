namespace Endfix.Telegram.BotAPI.Types;

public sealed class PaidMediaPurchased
{
    public required User From { get; init; }

    public required string PaidMediaPayload { get; init; }
}
