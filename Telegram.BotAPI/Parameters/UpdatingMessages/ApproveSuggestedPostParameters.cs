namespace Telegram.BotAPI.Parameters;

public sealed class ApproveSuggestedPostParameters : ApiRequestParameters
{
    public long ChatId { get; set; }

    public int MessageId { get; set; }

    public int SendDate { get; set; }
}
