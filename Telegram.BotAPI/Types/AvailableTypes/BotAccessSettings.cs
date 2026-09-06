using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes the access settings of a bot.
/// </summary>
public sealed class BotAccessSettings
{
    /// <summary>
    /// True if only selected users can access the bot. The bot's owner can always access it.
    /// </summary>
    public required bool IsAccessRestricted { get; init; }

    /// <summary>
    /// The list of other users who have access to the bot if access is restricted.
    /// </summary>
    public IReadOnlyList<User>? AddedUsers { get; init; }
}
