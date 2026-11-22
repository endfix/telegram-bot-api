using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Full information about the bot itself, returned by <c>getMe</c>.
/// </summary>
public sealed class BotFullInfo
{
    /// <summary>Unique identifier for the bot.</summary>
    public required long Id { get; init; }

    /// <summary>Always <see langword="true"/>.</summary>
    public required bool IsBot { get; init; }

    /// <summary>The bot's first name.</summary>
    public required string FirstName { get; init; }

    /// <summary>The bot's username, if available.</summary>
    public string? Username { get; init; }

    /// <summary>All active usernames of the bot, if it has any.</summary>
    public IReadOnlyList<string>? ActiveUsernames { get; init; }

    /// <summary>Whether the bot can be added to groups.</summary>
    public required bool CanJoinGroups { get; init; }

    /// <summary>Whether privacy mode is disabled for the bot.</summary>
    public required bool CanReadAllGroupMessages { get; init; }

    /// <summary>Whether the bot supports guest queries from chats it is not a member of.</summary>
    public required bool SupportsGuestQueries { get; init; }

    /// <summary>Whether the bot supports inline queries.</summary>
    public required bool SupportsInlineQueries { get; init; }

    /// <summary>Placeholder shown after the bot's username in inline mode; omitted when the default placeholder is used.</summary>
    public string? InlineQueryPlaceholder { get; init; }

    /// <summary>Whether the bot requests the user's location with every inline query.</summary>
    public required bool NeedsInlineQueryLocation { get; init; }

    /// <summary>Whether the bot can be connected to a user account to manage it.</summary>
    public required bool CanConnectToBusiness { get; init; }

    /// <summary>Whether the bot has a main Web App.</summary>
    public required bool HasMainWebApp { get; init; }

    /// <summary>Whether forum topic mode is enabled in private chats with the bot.</summary>
    public required bool HasTopicsEnabled { get; init; }

    /// <summary>Whether users can create and delete topics in private chats with the bot.</summary>
    public required bool AllowsUsersToCreateTopics { get; init; }

    /// <summary>Whether topics in private chats with the bot are shown in a sidebar.</summary>
    public required bool HasTopicSidebar { get; init; }

    /// <summary>Whether the bot can create other bots that it controls.</summary>
    public required bool CanManageBots { get; init; }

    /// <summary>Whether the bot supports join request queries and can be assigned to process them.</summary>
    public required bool SupportsJoinRequestQueries { get; init; }
}
