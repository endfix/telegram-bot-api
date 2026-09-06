namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes a service message about the failed approval of a suggested post.
/// </summary>
public sealed class SuggestedPostApprovalFailed
{
    /// <summary>Optional message containing the suggested post whose approval has failed.</summary>
    public Message? SuggestedPostMessage { get; init; }

    /// <summary>Expected price of the post.</summary>
    public required SuggestedPostPrice Price { get; init; }
}
