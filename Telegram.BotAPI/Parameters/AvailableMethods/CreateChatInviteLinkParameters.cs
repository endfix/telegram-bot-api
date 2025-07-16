namespace Telegram.BotAPI.Parameters;

public sealed class CreateChatInviteLinkParameters : ApiRequestParameters
{
    public object ChatId { get; set; }

    public string Name { get; set; }

    public int ExpireDate { get; set; }

    public int MemberLimit { get; set; }

    public bool CreatesJoinRequest { get; set; }
}
