using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>restrictChatMember</c> method.
/// </summary>
public sealed class RestrictChatMemberParameters : ApiRequestParameters
{
    /// <summary>Target supergroup identifier or username.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>Target user identifier.</summary>
    public required long UserId { get; init; }

    /// <summary>Permissions to grant to the user. Grant all permissions to lift restrictions.</summary>
    public required ChatPermissions Permissions { get; init; }

    /// <summary>Whether chat permissions are applied independently instead of using Telegram's implied permission relationships.</summary>
    public bool? UseIndependentChatPermissions { get; init; }

    /// <summary>Unix timestamp when restrictions are lifted. A duration under 30 seconds or over 366 days is treated as permanent.</summary>
    public int? UntilDate { get; init; }
}
