using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>answerWebAppQuery</c> method.
/// </summary>
public sealed class AnswerWebAppQueryParameters : ApiRequestParameters
{
    /// <summary>Unique identifier of the Web App query.</summary>
    public required string WebAppQueryId { get; init; }

    /// <summary>Description of the message to send on behalf of the user.</summary>
    public required InlineQueryResult Result { get; init; }
}
