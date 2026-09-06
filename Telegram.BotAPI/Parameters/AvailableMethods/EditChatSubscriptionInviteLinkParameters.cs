using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>editChatSubscriptionInviteLink</c> method.
/// </summary>
public sealed class EditChatSubscriptionInviteLinkParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }

    public required string InviteLink { get; init; }

    public string? Name { get; init; }
}
