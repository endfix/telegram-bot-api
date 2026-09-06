using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>answerPreCheckoutQuery</c> method.
/// </summary>
public sealed class AnswerPreCheckoutQueryParameters : ApiRequestParameters
{
    /// <summary>Unique identifier of the pre-checkout query.</summary>
    public required string PreCheckoutQueryId { get; init; }

    /// <summary>Whether the order can proceed.</summary>
    public required bool Ok { get; init; }

    /// <summary>Human-readable reason for failure. Required when <see cref="Ok"/> is <see langword="false"/>.</summary>
    public string? ErrorMessage { get; init; }
}
