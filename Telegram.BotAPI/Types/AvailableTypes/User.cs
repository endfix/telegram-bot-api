namespace Telegram.BotAPI.Types;

public sealed class User
{
    public required long Id { get; init; }

    public required bool IsBot { get; init; }

    public required string FirstName { get; init; }

    public string? LastName { get; init; }

    public string? Username { get; init; }

    public string? LanguageCode { get; init; }

    public bool? IsPremium { get; init; }

    public bool? AddedToAttachmentMenu { get; init; }

    public bool? CanJoinGroups { get; init; }

    public bool? CanReadAllGroupMessages { get; init; }

    public bool? SupportsGuestQueries { get; init; }

    public bool? SupportsInlineQueries { get; init; }

    public bool? CanConnectToBusiness { get; init; }

    public bool? HasMainWebApp { get; init; }

    public bool? HasTopicsEnabled { get; init; }

    public bool? AllowsUsersToCreateTopics { get; init; }

    public bool? CanManageBots { get; init; }
}
