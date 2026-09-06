namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Contains information about a bot created to be managed by the current bot.</summary>
public sealed class ManagedBotCreated
{
    /// <summary>Information about the managed bot. Its token can be fetched using <c>getManagedBotToken</c>.</summary>
    public required User Bot { get; init; }
}
