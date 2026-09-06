namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes a keyboard button to be used by a user of a Mini App.
/// </summary>
public sealed class PreparedKeyboardButton
{
    /// <summary>Unique identifier of the keyboard button.</summary>
    public required string Id { get; init; }
}
