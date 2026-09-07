using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>revokeChatInviteLink</c> method.
/// </summary>
public sealed class RevokeChatInviteLinkParameters : ApiRequestParameters
{
    /// <summary>Target chat identifier or channel username.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>Invite link to revoke.</summary>
    public required string InviteLink { get; init; }
}
