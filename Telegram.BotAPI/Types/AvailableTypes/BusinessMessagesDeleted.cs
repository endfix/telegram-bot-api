namespace Telegram.BotAPI.Types;

public sealed class BusinessMessagesDeleted
{
    public string BusinessConnectionId { get; set; }

    public Chat Chat { get; set; }

    public int[] MessageIds { get; set; }
}
