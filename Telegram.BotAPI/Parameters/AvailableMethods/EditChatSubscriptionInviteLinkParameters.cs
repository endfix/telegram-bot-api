using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>editChatSubscriptionInviteLink</c> method.
/// </summary>
public sealed class EditChatSubscriptionInviteLinkParameters : ApiRequestParameters
{
    /// <summary>Target channel identifier or username.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>Subscription invite link to edit.</summary>
    public required string InviteLink { get; init; }

    /// <summary>Invite link name, from 0 through 32 characters.</summary>
    public string? Name { get; init; }
}
