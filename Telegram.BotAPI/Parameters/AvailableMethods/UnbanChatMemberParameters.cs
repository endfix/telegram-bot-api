namespace Telegram.BotAPI.Parameters;

public sealed class UnbanChatMemberParameters : ApiRequestParameters
{
    public object ChatId { get; set; }

    public long UserId { get; set; }

    public bool OnlyIfBanned { get; set; }
}
