namespace Telegram.BotAPI.Types;

public sealed class BotCommand
{
    public required string Command { get; init; }

    public required string Description { get; init; }

    public bool? IsEphemeral { get; init; }
}
