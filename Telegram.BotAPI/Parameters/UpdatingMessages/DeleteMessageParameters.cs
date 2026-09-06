using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>deleteMessage</c> method.
/// </summary>
public sealed class DeleteMessageParameters : ApiRequestParameters
{
    /// <summary>Chat containing the message.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>Identifier of the message to delete.</summary>
    public required long MessageId { get; init; }
}
