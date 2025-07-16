namespace Telegram.BotAPI.Parameters;

public sealed class RevokeChatInviteLinkParameters : ApiRequestParameters
{
    public object ChatId { set; get; }

    public string InviteLink { set; get; }
}
