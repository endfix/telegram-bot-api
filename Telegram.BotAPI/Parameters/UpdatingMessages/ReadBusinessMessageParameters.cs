namespace Telegram.BotAPI.Parameters;

public sealed class ReadBusinessMessageParameters : ApiRequestParameters
{
    public string BusinessConnectionId { get; set; }

    public long ChatId { get; set; }

    public int MessageId { get; set; }
}
