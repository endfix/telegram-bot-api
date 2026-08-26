namespace Endfix.Telegram.BotAPI.Types;

public sealed class SuggestedPostPaid
{
    public Message? SuggestedPostMessage { get; init; }

    public required string Currency { get; init; }

    public int? Amount { get; init; }

    public StarAmount? StarAmount { get; init; }
}
