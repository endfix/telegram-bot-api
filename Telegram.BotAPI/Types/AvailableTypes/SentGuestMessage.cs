namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes an inline message sent by a guest bot.
/// </summary>
public sealed class SentGuestMessage
{
    /// <summary>Identifier of the sent inline message.</summary>
    public required string InlineMessageId { get; init; }
}
