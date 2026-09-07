using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>closeGeneralForumTopic</c> method.
/// </summary>
public sealed class CloseGeneralForumTopicParameters : ApiRequestParameters
{
    /// <summary>Gets the unique identifier or username of the target forum supergroup.</summary>
    public required ChatIdSource ChatId { get; init; }
}
