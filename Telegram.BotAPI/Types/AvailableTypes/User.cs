namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents a Telegram user or bot.</summary>
public sealed class User
{
    /// <summary>Unique identifier for this user or bot.</summary>
    public required long Id { get; init; }

    /// <summary>Indicates whether this user is a bot.</summary>
    public required bool IsBot { get; init; }

    /// <summary>The user's or bot's first name.</summary>
    public required string FirstName { get; init; }

    /// <summary>The user's or bot's last name, if available.</summary>
    public string? LastName { get; init; }

    /// <summary>The user's or bot's username, if available.</summary>
    public string? Username { get; init; }

    /// <summary>Optional IETF language tag of the user's language.</summary>
    public string? LanguageCode { get; init; }

    /// <summary>Indicates whether this user is a Telegram Premium user.</summary>
    public bool? IsPremium { get; init; }

    /// <summary>Indicates whether this user added the bot to the attachment menu.</summary>
    public bool? AddedToAttachmentMenu { get; init; }

    /// <summary>Indicates whether the bot can be invited to groups. No longer returned by <c>getMe</c> since Bot API 10.5; use <see cref="BotFullInfo"/>.</summary>
    public bool? CanJoinGroups { get; init; }

    /// <summary>Indicates whether privacy mode is disabled for the bot. No longer returned by <c>getMe</c> since Bot API 10.5; use <see cref="BotFullInfo"/>.</summary>
    public bool? CanReadAllGroupMessages { get; init; }

    /// <summary>Indicates whether the bot supports guest queries from chats it is not a member of. No longer returned by <c>getMe</c> since Bot API 10.5; use <see cref="BotFullInfo"/>.</summary>
    public bool? SupportsGuestQueries { get; init; }

    /// <summary>Indicates whether the bot supports inline queries. No longer returned by <c>getMe</c> since Bot API 10.5; use <see cref="BotFullInfo"/>.</summary>
    public bool? SupportsInlineQueries { get; init; }

    /// <summary>Indicates whether the bot can be connected to a user account to manage it. No longer returned by <c>getMe</c> since Bot API 10.5; use <see cref="BotFullInfo"/>.</summary>
    public bool? CanConnectToBusiness { get; init; }

    /// <summary>Indicates whether the bot has a main Web App. No longer returned by <c>getMe</c> since Bot API 10.5; use <see cref="BotFullInfo"/>.</summary>
    public bool? HasMainWebApp { get; init; }

    /// <summary>Indicates whether the bot has forum topic mode enabled in private chats. No longer returned by <c>getMe</c> since Bot API 10.5; use <see cref="BotFullInfo"/>.</summary>
    public bool? HasTopicsEnabled { get; init; }

    /// <summary>Indicates whether the bot allows users to create and delete topics in private chats. No longer returned by <c>getMe</c> since Bot API 10.5; use <see cref="BotFullInfo"/>.</summary>
    public bool? AllowsUsersToCreateTopics { get; init; }

    /// <summary>Indicates whether other bots can be created to be controlled by this bot. No longer returned by <c>getMe</c> since Bot API 10.5; use <see cref="BotFullInfo"/>.</summary>
    public bool? CanManageBots { get; init; }

    /// <summary>Indicates whether the bot supports join request queries and can be assigned to process them. No longer returned by <c>getMe</c> since Bot API 10.5; use <see cref="BotFullInfo"/>.</summary>
    public bool? SupportsJoinRequestQueries { get; init; }
}
