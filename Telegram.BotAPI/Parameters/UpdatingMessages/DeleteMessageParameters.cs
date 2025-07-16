namespace Telegram.BotAPI.Parameters;

public sealed class DeleteMessageParameters : ApiRequestParameters
{
    public object ChatId { get; set; }

    public long MessageId { get; set; }
}
