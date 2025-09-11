namespace Telegram.BotAPI.Types;

public sealed class SuggestedPostApprovalFailed
{
    public Message SuggestedPostMessage { get; set; }

    public SuggestedPostPrice Price { get; set; }
}
