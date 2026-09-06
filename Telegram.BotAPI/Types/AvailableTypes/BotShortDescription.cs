namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes a bot's short description.
/// </summary>
public sealed class BotShortDescription
{
    /// <summary>
    /// The bot's short description.
    /// </summary>
    public required string ShortDescription { get; init; }
}
