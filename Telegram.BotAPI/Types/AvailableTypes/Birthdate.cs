namespace Endfix.Telegram.BotAPI.Types;

public sealed class Birthdate
{
    public required int Day { get; init; }

    public required int Month { get; init; }

    public int? Year { get; init; }
}
