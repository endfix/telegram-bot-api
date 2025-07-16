namespace Telegram.BotAPI.Parameters;

public sealed class GetUserChatBoostsParameters : ApiRequestParameters
{
    public object ChatId { get; set; }

    public long UserId { get; set; }
}
