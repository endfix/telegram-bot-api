using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public sealed class SuggestedPostRefunded
{
    public Message? SuggestedPostMessage { get; init; }

    public required SuggestedPostRefundedReason Reason { get; init; }
}
