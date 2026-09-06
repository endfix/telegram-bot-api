using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setChatPermissions</c> method.
/// </summary>
public sealed class SetChatPermissionsParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }

    public required ChatPermissions Permissions { get; init; }

    public bool? UseIndependentChatPermissions { get; init; }
}
