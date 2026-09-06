using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes a service message about a payment refund for a suggested post.
/// </summary>
public sealed class SuggestedPostRefunded
{
    /// <summary>Optional message containing the suggested post.</summary>
    public Message? SuggestedPostMessage { get; init; }

    /// <summary>Reason for the refund.</summary>
    public required SuggestedPostRefundedReason Reason { get; init; }
}
