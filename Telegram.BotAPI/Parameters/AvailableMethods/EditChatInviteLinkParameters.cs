namespace Telegram.BotAPI.Parameters;

public sealed class EditChatInviteLinkParameters : ApiRequestParameters
{
    public required object ChatId { get; init; }

    public required string InviteLink { get; init; }

    public string? Name { get; init; }

    public int? ExpireDate { get; init; }

    public int? MemberLimit { get; init; }

    public bool? CreatesJoinRequest { get; init; }
}
