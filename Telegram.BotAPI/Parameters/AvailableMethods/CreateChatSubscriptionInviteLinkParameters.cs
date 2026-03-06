namespace Telegram.BotAPI.Parameters;

public sealed class CreateChatSubscriptionInviteLinkParameters : ApiRequestParameters
{
    public required object ChatId { get; init; }

    public string? Name { get; init; }

    public required int SubscriptionPeriod { get; init; }

    public required int SubscriptionPrice { get; init; }
}
