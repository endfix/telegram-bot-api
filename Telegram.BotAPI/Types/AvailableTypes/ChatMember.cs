namespace Telegram.BotAPI.Types.AvailableTypes;

public abstract class ChatMember
{
    public abstract string Status { get; }

    public User User { get; set; }

    public static class Statuses
    {
        public const string CREATOR = "creator";

        public const string ADMINISTRATOR = "administrator";

        public const string MEMBER = "member";

        public const string RESTRICTED = "restricted";

        public const string LEFT = "left";

        public const string KICKED = "kicked";
    }
}

public sealed class ChatMemberAdministrator : ChatMember
{
    public override string Status => Statuses.ADMINISTRATOR;

    public bool CanBeEdited { get; set; }

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

    public string CustomTitle { get; set; }
}

public sealed class ChatMemberBanned : ChatMember
{
    public override string Status => Statuses.KICKED;

    public int UntilDate { get; set; }
}

public sealed class ChatMemberLeft : ChatMember
{
    public override string Status => Statuses.LEFT;
}

public sealed class ChatMemberMember : ChatMember
{
    public override string Status => Statuses.MEMBER;

    public int UntilDate { get; set; }
}

public sealed class ChatMemberOwner : ChatMember
{
    public override string Status => Statuses.CREATOR;

    public bool IsAnonymous { get; set; }

    public string CustomTitle { get; set; }
}

public sealed class ChatMemberRestricted : ChatMember
{
    public override string Status => Statuses.RESTRICTED;

    public bool IsMember { get; set; }

    public bool CanSendMessages { get; set; }

    public bool CanSendAudios { get; set; }

    public bool CanSendDocuments { get; set; }

    public bool CanSendPhotos { get; set; }

    public bool CanSendVideos { get; set; }

    public bool CanSendVideoNotes { get; set; }

    public bool CanSendVoiceNotes { get; set; }

    public bool CanSendPolls { get; set; }

    public bool CanSendOtherMessages { get; set; }

    public bool CanAddWebPagePreviews { get; set; }

    public bool CanChangeInfo { get; set; }

    public bool CanInviteUsers { get; set; }

    public bool CanPinMessages { get; set; }

    public bool CanManageTopics { get; set; }

    public int UntilDate { get; set; }
}
