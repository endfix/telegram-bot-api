using Telegram.BotAPI.Protocol;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class EditChatSubscriptionInviteLinkParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }

    public required string InviteLink { get; init; }

    public string? Name { get; init; }
}
