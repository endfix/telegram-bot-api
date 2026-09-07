using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setManagedBotAccessSettings</c> method.
/// </summary>
public sealed class SetManagedBotAccessSettingsParameters : ApiRequestParameters
{
    /// <summary>Identifier of the managed bot.</summary>
    public required long UserId { get; init; }

    /// <summary>Whether only selected users may access the managed bot.</summary>
    public required bool IsAccessRestricted { get; init; }

    /// <summary>Up to 10 additional user identifiers that retain access. Ignored when <see cref="IsAccessRestricted"/> is <see langword="false"/>.</summary>
    public IReadOnlyList<long>? AddedUserIds { get; init; }
}
