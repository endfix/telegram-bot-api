using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

public sealed class SuggestedPostRefunded
{
    public Message? SuggestedPostMessage { get; init; }

    public required SuggestedPostRefundedReason Reason { get; init; }
}
