using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public abstract class ChatMember
{
    public abstract ChatMemberStatus Status { get; }

    public required virtual User User { get; init; }
}

public sealed class ChatMemberAdministrator : ChatMember
{
    public override ChatMemberStatus Status => ChatMemberStatus.Administrator;

    public required bool CanBeEdited { get; init; }

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

    public bool? CanSendWelcomeMessages { get; init; }

    public string? CustomTitle { get; init; }
}

public sealed class ChatMemberBanned : ChatMember
{
    public override ChatMemberStatus Status => ChatMemberStatus.Kicked;

    public required int UntilDate { get; init; }
}

public sealed class ChatMemberLeft : ChatMember
{
    public override ChatMemberStatus Status => ChatMemberStatus.Left;
}

public sealed class ChatMemberMember : ChatMember
{
    public override ChatMemberStatus Status => ChatMemberStatus.Member;

    public string? Tag { get; init; }

    public int? UntilDate { get; init; }
}

public sealed class ChatMemberOwner : ChatMember
{
    public override ChatMemberStatus Status => ChatMemberStatus.Creator;

    public required bool IsAnonymous { get; init; }

    public string? CustomTitle { get; init; }
}

public sealed class ChatMemberRestricted : ChatMember
{
    public override ChatMemberStatus Status => ChatMemberStatus.Restricted;

    public string? Tag { get; init; }

    public required bool IsMember { get; init; }

    public required bool CanSendMessages { get; init; }

    public required bool CanSendAudios { get; init; }

    public required bool CanSendDocuments { get; init; }

    public required bool CanSendPhotos { get; init; }

    public required bool CanSendVideos { get; init; }

    public required bool CanSendVideoNotes { get; init; }

    public required bool CanSendVoiceNotes { get; init; }

    public required bool CanSendPolls { get; init; }

    public required bool CanSendOtherMessages { get; init; }

    public required bool CanAddWebPagePreviews { get; init; }

    public required bool CanReactToMessages { get; init; }

    public required bool CanEditTag { get; init; }

    public required bool CanChangeInfo { get; init; }

    public required bool CanInviteUsers { get; init; }

    public required bool CanPinMessages { get; init; }

    public required bool CanManageTopics { get; init; }

    public required int UntilDate { get; init; }
}
