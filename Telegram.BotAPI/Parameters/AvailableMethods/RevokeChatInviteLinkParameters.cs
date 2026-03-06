namespace Telegram.BotAPI.Parameters;

public sealed class RevokeChatInviteLinkParameters : ApiRequestParameters
{
    public required object ChatId { get; init; }

    public required string InviteLink { get; init; }
}
