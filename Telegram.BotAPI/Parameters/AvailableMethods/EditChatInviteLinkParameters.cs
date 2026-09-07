using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>editChatInviteLink</c> method.
/// </summary>
public sealed class EditChatInviteLinkParameters : ApiRequestParameters
{
    /// <summary>Target chat identifier or channel username.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>Invite link to edit.</summary>
    public required string InviteLink { get; init; }

    /// <summary>Invite link name, from 0 through 32 characters.</summary>
    public string? Name { get; init; }

    /// <summary>Unix timestamp when the link expires.</summary>
    public int? ExpireDate { get; init; }

    /// <summary>Maximum simultaneous members who joined through the link, from 1 through 99999.</summary>
    public int? MemberLimit { get; init; }

    /// <summary>Whether users joining through the link require administrator approval. Cannot be combined with <see cref="MemberLimit"/>.</summary>
    public bool? CreatesJoinRequest { get; init; }
}
