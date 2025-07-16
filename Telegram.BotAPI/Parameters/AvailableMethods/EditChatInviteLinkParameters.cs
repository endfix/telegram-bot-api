namespace Telegram.BotAPI.Parameters;

public sealed class EditChatInviteLinkParameters : ApiRequestParameters
{
    public object ChatId { get; set; }

    public string InviteLink { get; set; }

    public string Name { set; get; }

    public int ExpireDate { set; get; }

    public int MemberLimit { get; set; }

    public bool CreatesJoinRequest { set; get; }
}
