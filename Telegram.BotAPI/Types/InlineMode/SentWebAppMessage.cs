namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes an inline message sent by a Web App on behalf of a user.
/// </summary>
public sealed class SentWebAppMessage
{
    /// <summary>Optional identifier of the sent inline message.</summary>
    public string? InlineMessageId { get; init; }
}
