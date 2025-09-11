namespace Telegram.BotAPI.Types;

public sealed class SuggestedPostRefunded
{
    public Message SuggestedPostMessage { get; set; }

    public string Reason { get; set; }
}
