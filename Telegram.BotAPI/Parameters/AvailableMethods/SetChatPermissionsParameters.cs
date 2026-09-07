using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setChatPermissions</c> method.
/// </summary>
public sealed class SetChatPermissionsParameters : ApiRequestParameters
{
    /// <summary>Target group or supergroup identifier or username.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>New default chat permissions.</summary>
    public required ChatPermissions Permissions { get; init; }

    /// <summary>Whether permissions are applied independently instead of using Telegram's implied permission relationships.</summary>
    public bool? UseIndependentChatPermissions { get; init; }
}
