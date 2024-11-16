namespace Telegram.BotAPI.Types.AvailableTypes;

public sealed class InaccessibleMessage
{
    public Chat Chat { get; set; }

    public int MessageId { get; set; }

    public int Date { get; set; }
}
