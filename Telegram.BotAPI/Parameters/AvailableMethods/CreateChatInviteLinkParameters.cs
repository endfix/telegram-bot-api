using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>createChatInviteLink</c> method.
/// </summary>
public sealed class CreateChatInviteLinkParameters : ApiRequestParameters
{
    /// <summary>Gets the unique identifier or username of the target channel or chat.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>Gets the invite link name, containing 0-32 characters.</summary>
    public string? Name { get; init; }

    /// <summary>Gets the point in time when the link expires, as a Unix timestamp.</summary>
    public int? ExpireDate { get; init; }

    /// <summary>Gets the maximum number of users who may be chat members simultaneously after joining through the link; 1-99999.</summary>
    public int? MemberLimit { get; init; }

    /// <summary>Gets whether users joining through the link must be approved by chat administrators. When <see langword="true"/>, <see cref="MemberLimit"/> must not be specified.</summary>
    public bool? CreatesJoinRequest { get; init; }
}
