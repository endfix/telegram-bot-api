using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>answerGuestQuery</c> method.
/// </summary>
public sealed class AnswerGuestQueryParameters : ApiRequestParameters
{
    public required string GuestQueryId { get; init; }

    public required InlineQueryResult Result { get; init; }
}
