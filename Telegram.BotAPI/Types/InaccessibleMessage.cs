namespace Telegram.BotAPI.Types;

// https://core.telegram.org/bots/api#inaccessiblemessage
public sealed class InaccessibleMessage
{
    public Chat Chat { get; set; }

    public int MessageId { get; set; }

    public int Date { get; set; }
}
