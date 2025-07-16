using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public abstract class ChatMember
{
    public abstract ChatMemberStatus Status { get; }

    public User User { get; set; }
}

public sealed class ChatMemberAdministrator : ChatMember
{
    public override ChatMemberStatus Status => ChatMemberStatus.Administrator;

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
    public override ChatMemberStatus Status => ChatMemberStatus.Kicked;

    public int UntilDate { get; set; }
}

public sealed class ChatMemberLeft : ChatMember
{
    public override ChatMemberStatus Status => ChatMemberStatus.Left;
}

public sealed class ChatMemberMember : ChatMember
{
    public override ChatMemberStatus Status => ChatMemberStatus.Member;

    public int UntilDate { get; set; }
}

public sealed class ChatMemberOwner : ChatMember
{
    public override ChatMemberStatus Status => ChatMemberStatus.Creator;

    public bool IsAnonymous { get; set; }

    public string CustomTitle { get; set; }
}

public sealed class ChatMemberRestricted : ChatMember
{
    public override ChatMemberStatus Status => ChatMemberStatus.Restricted;

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
