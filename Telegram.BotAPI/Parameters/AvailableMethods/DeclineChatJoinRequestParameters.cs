namespace Telegram.BotAPI.Parameters;

public sealed class DeclineChatJoinRequestParameters : ApiRequestParameters
{
    public object ChatId { set; get; }

    public long UserId { set; get; }
}
