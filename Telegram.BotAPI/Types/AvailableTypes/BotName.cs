namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes a bot's name.
/// </summary>
public sealed class BotName
{
    /// <summary>
    /// The bot's name.
    /// </summary>
    public required string Name { get; init; }
}
