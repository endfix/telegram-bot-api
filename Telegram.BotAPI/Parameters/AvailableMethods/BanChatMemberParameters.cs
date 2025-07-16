namespace Telegram.BotAPI.Parameters;

public sealed class BanChatMemberParameters : ApiRequestParameters
{
    public object ChatId { get; set; }

    public long UserId { get; set; }

    public int UntilDate { get; set; }

    public bool RevokeMessages { get; set; }
}
