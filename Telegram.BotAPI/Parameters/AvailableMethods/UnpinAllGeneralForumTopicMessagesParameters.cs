using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>unpinAllGeneralForumTopicMessages</c> method.
/// </summary>
public sealed class UnpinAllGeneralForumTopicMessagesParameters : ApiRequestParameters
{
    /// <summary>Target forum supergroup identifier or username.</summary>
    public required ChatIdSource ChatId { get; init; }
}
