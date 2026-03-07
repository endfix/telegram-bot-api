namespace Telegram.BotAPI.Types;

public sealed class ChatLocation
{
    public required Location Location { get; init; }

    public required string Address { get; init; }
}
