namespace Telegram.BotAPI.Parameters;

public sealed class EditChatSubscriptionInviteLinkParameters : ApiRequestParameters
{
    public required object ChatId { get; init; }

    public required string InviteLink { get; init; }

    public string? Name { get; init; }
}
