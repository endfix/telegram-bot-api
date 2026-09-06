using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Contains information about a user whose identifier was shared with the bot.
/// </summary>
public sealed class SharedUser
{
    /// <summary>Identifier of the shared user.</summary>
    public required long UserId { get; init; }

    /// <summary>Optional first name of the user, if requested by the bot.</summary>
    public string? FirstName { get; init; }

    /// <summary>Optional last name of the user, if requested by the bot.</summary>
    public string? LastName { get; init; }

    /// <summary>Optional username of the user, if requested by the bot.</summary>
    public string? Username { get; init; }

    /// <summary>Optional available sizes of the user's photo, if requested by the bot.</summary>
    public IReadOnlyList<PhotoSize>? Photo { get; init; }
}
