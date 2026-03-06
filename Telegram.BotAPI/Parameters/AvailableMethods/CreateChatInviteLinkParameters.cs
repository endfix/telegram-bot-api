namespace Telegram.BotAPI.Parameters;

public sealed class CreateChatInviteLinkParameters : ApiRequestParameters
{
    public required object ChatId { get; init; }

    public string? Name { get; init; }

    public int? ExpireDate { get; init; }

    public int? MemberLimit { get; init; }

    public bool? CreatesJoinRequest { get; init; }
}
