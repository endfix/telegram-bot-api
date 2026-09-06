namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes a service message about a change in auto-delete timer settings.
/// </summary>
public sealed class MessageAutoDeleteTimerChanged
{
    /// <summary>New auto-delete time for messages in the chat, in seconds.</summary>
    public required int MessageAutoDeleteTime { get; init; }
}
