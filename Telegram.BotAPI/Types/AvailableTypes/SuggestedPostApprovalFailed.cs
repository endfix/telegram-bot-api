namespace Endfix.Telegram.BotAPI.Types;

public sealed class SuggestedPostApprovalFailed
{
    public Message? SuggestedPostMessage { get; init; }

    public required SuggestedPostPrice Price { get; init; }
}
