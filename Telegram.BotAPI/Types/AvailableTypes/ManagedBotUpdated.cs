namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Contains information about a managed bot whose owner, token or creation state changed.</summary>
public sealed class ManagedBotUpdated
{
    /// <summary>User who created or updated the managed bot.</summary>
    public required User User { get; init; }

    /// <summary>Information about the managed bot. Its token can be fetched using <c>getManagedBotToken</c>.</summary>
    public required User Bot { get; init; }
}
