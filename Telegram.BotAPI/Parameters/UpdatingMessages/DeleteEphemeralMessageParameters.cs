using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>deleteEphemeralMessage</c> method.
/// </summary>
public sealed class DeleteEphemeralMessageParameters : ApiRequestParameters
{
    /// <summary>Chat containing the ephemeral message.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>Identifier of the user who received the message.</summary>
    public required long ReceiverUserId { get; init; }

    /// <summary>Identifier of the ephemeral message.</summary>
    public required long EphemeralMessageId { get; init; }
}
