namespace Telegram.BotAPI.Types;

public sealed class ManagedBotUpdated
{
    public required User User { get; init; }

    public required User Bot { get; init; }
}
