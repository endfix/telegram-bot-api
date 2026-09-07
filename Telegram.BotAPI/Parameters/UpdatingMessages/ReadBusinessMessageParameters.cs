using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>readBusinessMessage</c> method.
/// </summary>
public sealed class ReadBusinessMessageParameters : ApiRequestParameters
{
    /// <summary>Identifier of the business connection.</summary>
    public required string BusinessConnectionId { get; init; }

    /// <summary>Identifier of the chat where the message was received; the chat must have been active within the last 24 hours.</summary>
    public required long ChatId { get; init; }

    /// <summary>Identifier of the message to mark as read.</summary>
    public required long MessageId { get; init; }
}
