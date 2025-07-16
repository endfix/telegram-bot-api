namespace Telegram.BotAPI.Parameters;

public sealed class GetChatMemberParameters : ApiRequestParameters
{
    public object ChatId { get; set; }

    public long UserId { get; set; }
}
