using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>answerWebAppQuery</c> method.
/// </summary>
public sealed class AnswerWebAppQueryParameters : ApiRequestParameters
{
    public required string WebAppQueryId { get; init; }

    public required InlineQueryResult Result { get; init; }
}
