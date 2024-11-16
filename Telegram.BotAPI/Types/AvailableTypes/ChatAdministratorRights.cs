namespace Telegram.BotAPI.Types.AvailableTypes;

public sealed class ChatAdministratorRights
{
    public bool IsAnonymous { get; set; }

    public bool CanManageChat { get; set; }

    public bool CanDeleteMessages { get; set; }

    public bool CanManageVideoChats { get; set; }

    public bool CanRestrictMembers { get; set; }

    public bool CanPromoteMembers { get; set; }

    public bool CanChangeInfo { get; set; }

    public bool CanInviteUsers { get; set; }

    public bool CanPostStories { get; set; }

    public bool CanEditStories { get; set; }

    public bool CanDeleteStories { get; set; }

    public bool CanPostMessages { get; set; }

    public bool CanEditMessages { get; set; }

    public bool CanPinMessages { get; set; }

    public bool CanManageTopics { get; set; }
}
