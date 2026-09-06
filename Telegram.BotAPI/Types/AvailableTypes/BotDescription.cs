namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes a bot's description.
/// </summary>
public sealed class BotDescription
{
    /// <summary>
    /// The bot's description.
    /// </summary>
    public required string Description { get; init; }
}
