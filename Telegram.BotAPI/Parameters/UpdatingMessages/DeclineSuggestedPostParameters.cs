using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>declineSuggestedPost</c> method.
/// </summary>
public sealed class DeclineSuggestedPostParameters : ApiRequestParameters
{
    /// <summary>Channel chat containing the suggested post.</summary>
    public required long ChatId { get; init; }

    /// <summary>Identifier of the suggested post message.</summary>
    public required long MessageId { get; init; }

    /// <summary>Optional comment explaining the rejection.</summary>
    public string? Comment { get; init; }
}
