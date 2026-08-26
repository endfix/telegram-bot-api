using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class CreateChatSubscriptionInviteLinkParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }

    public string? Name { get; init; }

    public required int SubscriptionPeriod { get; init; }

    public required int SubscriptionPrice { get; init; }
}
