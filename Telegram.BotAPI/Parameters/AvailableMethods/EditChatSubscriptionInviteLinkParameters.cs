namespace Telegram.BotAPI.Parameters;

public sealed class EditChatSubscriptionInviteLinkParameters : ApiRequestParameters
{
    public object ChatId { set; get; }

    public string InviteLink { set; get; }

    public string Name { set; get; }
}
