namespace Telegram.BotAPI.Parameters;

public sealed class CreateChatSubscriptionInviteLinkParameters : ApiRequestParameters
{
    public object ChatId { set; get; }

    public string Name { set; get; }

    public int SubscriptionPeriod { get; set; }

    public int SubscriptionPrice { get; set; }
}
