using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>unpinChatMessage</c> method.
/// </summary>
public sealed class UnpinChatMessageParameters : ApiRequestParameters
{
    /// <summary>Identifier of the business connection on whose behalf the message is unpinned.</summary>
    public string? BusinessConnectionId { get; init; }

    /// <summary>Target chat identifier or channel username.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>Identifier of the message to unpin. Required with <see cref="BusinessConnectionId"/>; otherwise the most recently sent pinned message is unpinned when omitted.</summary>
    public long? MessageId { get; init; }
}
