using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Contains information about users whose identifiers were shared with the bot using a request-users button.
/// </summary>
public sealed class UsersShared
{
    /// <summary>Identifier of the request.</summary>
    public required int RequestId { get; init; }

    /// <summary>Information about the shared users.</summary>
    public required IReadOnlyList<SharedUser> Users { get; init; }
}
