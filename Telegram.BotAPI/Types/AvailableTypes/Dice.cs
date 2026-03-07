namespace Telegram.BotAPI.Types;

public sealed class Dice
{
    public required string Emoji { get; init; }

    public required int Value { get; init; }
}
