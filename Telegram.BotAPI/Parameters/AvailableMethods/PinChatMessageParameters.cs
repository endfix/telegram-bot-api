using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>pinChatMessage</c> method.
/// </summary>
public sealed class PinChatMessageParameters : ApiRequestParameters
{
    /// <summary>Identifier of the business connection on whose behalf the message is pinned.</summary>
    public string? BusinessConnectionId { get; init; }

    /// <summary>Target chat identifier or channel username.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>Identifier of the message to pin.</summary>
    public required long MessageId { get; init; }

    /// <summary>Whether to suppress the notification about the new pinned message.</summary>
    public bool? DisableNotification { get; init; }
}
