namespace Telegram.BotAPI.Types;

public sealed class LabeledPrice
{
    public required string Label { get; init; }

    public required int Amount { get; init; }
}
