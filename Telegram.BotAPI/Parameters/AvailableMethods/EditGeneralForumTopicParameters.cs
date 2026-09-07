using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>editGeneralForumTopic</c> method.
/// </summary>
public sealed class EditGeneralForumTopicParameters : ApiRequestParameters
{
    /// <summary>Target forum supergroup identifier or username.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>New topic name, from 1 through 128 characters.</summary>
    public required string Name { get; init; }
}
