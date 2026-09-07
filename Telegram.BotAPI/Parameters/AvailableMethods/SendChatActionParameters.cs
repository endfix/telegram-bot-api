using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>sendChatAction</c> method.
/// </summary>
public sealed class SendChatActionParameters : ApiRequestParameters
{
    /// <summary>Identifier of the business connection on whose behalf the action is sent.</summary>
    public string? BusinessConnectionId { get; init; }

    /// <summary>Target chat identifier or username. Channels and channel direct messages are not supported.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>Target message thread identifier.</summary>
    public long? MessageThreadId { get; init; }

    /// <summary>Action to broadcast, such as <c>typing</c>, <c>upload_photo</c> or <c>record_video</c>.</summary>
    public required string Action { get; init; }
}
