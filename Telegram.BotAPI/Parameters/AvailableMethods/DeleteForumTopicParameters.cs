using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>deleteForumTopic</c> method.
/// </summary>
public sealed class DeleteForumTopicParameters : ApiRequestParameters
{
    /// <summary>Target chat identifier or supergroup username.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>Identifier of the forum topic's message thread.</summary>
    public required long MessageThreadId { get; init; }
}
