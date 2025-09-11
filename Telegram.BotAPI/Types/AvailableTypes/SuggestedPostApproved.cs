namespace Telegram.BotAPI.Types;

public sealed class SuggestedPostApproved
{
    public Message SuggestedPostMessage { get; set; }

    public SuggestedPostPrice Price { get; set; }

    public int SendDate { get; set; }
}
