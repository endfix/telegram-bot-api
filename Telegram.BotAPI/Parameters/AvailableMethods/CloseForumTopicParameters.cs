using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>closeForumTopic</c> method.
/// </summary>
public sealed class CloseForumTopicParameters : ApiRequestParameters
{
    /// <summary>Gets the unique identifier or username of the target supergroup.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>Gets the unique identifier of the target forum topic message thread.</summary>
    public required long MessageThreadId { get; init; }
}
