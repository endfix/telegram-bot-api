namespace Telegram.BotAPI.Types;

public sealed class SuggestedPostPaid
{
    public Message SuggestedPostMessage { get; set; }

    public string Currency { get; set; }

    public int Amount { get; set; }

    public StarAmount StarAmount { get; set; }
}
