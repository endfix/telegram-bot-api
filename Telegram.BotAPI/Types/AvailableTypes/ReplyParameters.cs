namespace Telegram.BotAPI.Types;

public sealed class ReplyParameters
{
    public long MessageId { get; set; }

    public object ChatId { get; set; }

    public bool AllowSendingWithoutReply { get; set; }

    public string Quote { get; set; } 

    public string QuoteParseMode { get; set; }

    public MessageEntity[] QuoteEntities { get; set; }

    public int QuotePosition { get; set; }
}
