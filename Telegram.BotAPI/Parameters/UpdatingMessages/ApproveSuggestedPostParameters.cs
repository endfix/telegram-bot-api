using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>approveSuggestedPost</c> method.
/// </summary>
public sealed class ApproveSuggestedPostParameters : ApiRequestParameters
{
    public required long ChatId { get; init; }

    public required long MessageId { get; init; }

    public int? SendDate { get; init; }
}
