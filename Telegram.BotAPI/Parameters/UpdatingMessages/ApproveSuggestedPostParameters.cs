using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>approveSuggestedPost</c> method.
/// </summary>
public sealed class ApproveSuggestedPostParameters : ApiRequestParameters
{
    /// <summary>Channel chat containing the suggested post.</summary>
    public required long ChatId { get; init; }

    /// <summary>Identifier of the suggested post message.</summary>
    public required long MessageId { get; init; }

    /// <summary>Unix timestamp when the post should be published.</summary>
    public int? SendDate { get; init; }
}
