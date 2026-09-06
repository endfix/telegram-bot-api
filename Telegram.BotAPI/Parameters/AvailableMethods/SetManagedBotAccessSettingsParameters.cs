using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setManagedBotAccessSettings</c> method.
/// </summary>
public sealed class SetManagedBotAccessSettingsParameters : ApiRequestParameters
{
    public required long UserId { get; init; }

    public required bool IsAccessRestricted { get; init; }

    public IReadOnlyList<long>? AddedUserIds { get; init; }
}
