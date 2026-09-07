using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>answerGuestQuery</c> method.
/// </summary>
public sealed class AnswerGuestQueryParameters : ApiRequestParameters
{
    /// <summary>Gets the unique identifier of the guest query to answer.</summary>
    public required string GuestQueryId { get; init; }

    /// <summary>Gets the result describing the message to send.</summary>
    public required InlineQueryResult Result { get; init; }
}
