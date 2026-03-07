namespace Telegram.BotAPI.Types;

public sealed class SuggestedPostPrice
{
    public required string Currency { get; init; }

    public required int Amount { get; init; }
}
