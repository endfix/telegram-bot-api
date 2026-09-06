namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Represents a bot command.
/// </summary>
public sealed class BotCommand
{
    /// <summary>
    /// Text of the command; 1-32 characters. Can contain only lowercase English letters, digits and underscores.
    /// </summary>
    public required string Command { get; init; }

    /// <summary>
    /// Description of the command; 1-256 characters.
    /// </summary>
    public required string Description { get; init; }

    /// <summary>
    /// True if the command sends an ephemeral message, which can be seen only by the sender of the message and the bot.
    /// </summary>
    public bool? IsEphemeral { get; init; }
}
