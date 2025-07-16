namespace Telegram.BotAPI.Parameters;

public sealed class DeleteMessagesParameters : ApiRequestParameters
{
    public object ChatId { get; set; }

    public long[] MessageIds { get; set; }
}
