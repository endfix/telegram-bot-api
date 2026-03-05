namespace Telegram.BotAPI.Types;

public sealed class ChatAdministratorRights
{
    public required bool IsAnonymous { get; init; }

    public required bool CanManageChat { get; init; }

    public required bool CanDeleteMessages { get; init; }

    public required bool CanManageVideoChats { get; init; }

    public required bool CanRestrictMembers { get; init; }

    public required bool CanPromoteMembers { get; init; }

    public required bool CanChangeInfo { get; init; }

    public required bool CanInviteUsers { get; init; }

    public required bool CanPostStories { get; init; }

    public required bool CanEditStories { get; init; }

    public required bool CanDeleteStories { get; init; }

    public bool? CanPostMessages { get; init; }

    public bool? CanEditMessages { get; init; }

    public bool? CanPinMessages { get; init; }

    public bool? CanManageTopics { get; init; }

    public bool? CanManageDirectMessages { get; init; }

    public bool? CanManageTags { get; init; }
}
