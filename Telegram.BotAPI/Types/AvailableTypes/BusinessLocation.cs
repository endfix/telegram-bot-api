namespace Endfix.Telegram.BotAPI.Types;

public sealed class BusinessLocation
{
    public required string Address { get; init; }

    public Location? Location { get; init; }
}
