namespace Telegram.BotAPI.Parameters;

public sealed class ApproveChatJoinRequestParameters : ApiRequestParameters
{
    public object ChatId { set; get; }

    public long UserId { set; get; }
}
