using System.Text.Json.Serialization;
using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "status")]
[JsonDerivedType(typeof(ChatMemberAdministrator), "administrator")]
[JsonDerivedType(typeof(ChatMemberBanned), "kicked")]
[JsonDerivedType(typeof(ChatMemberLeft), "left")]
[JsonDerivedType(typeof(ChatMemberMember), "member")]
[JsonDerivedType(typeof(ChatMemberOwner), "creator")]
[JsonDerivedType(typeof(ChatMemberRestricted), "restricted")]
public abstract class ChatMember
{
    [JsonIgnore]
    public abstract ChatMemberStatus Status { get; }

    public required User User { get; init; }
}

public sealed class ChatMemberAdministrator : ChatMember
{
    public override ChatMemberStatus Status => ChatMemberStatus.Administrator;

    public bool CanBeEdited { get; init; }

    public bool IsAnonymous { get; init; }

    public bool CanManageChat { get; init; }

    public bool CanDeleteMessages { get; init; }

    public bool CanManageVideoChats { get; init; }

    public bool CanRestrictMembers { get; init; }

    public bool CanPromoteMembers { get; init; }

    public bool CanChangeInfo { get; init; }

    public bool CanInviteUsers { get; init; }

    public bool CanPostStories { get; init; }

    public bool CanEditStories { get; init; }

    public bool CanDeleteStories { get; init; }

    public bool CanPostMessages { get; init; }

    public bool CanEditMessages { get; init; }

    public bool CanPinMessages { get; init; }

    public bool CanManageTopics { get; init; }

    public bool CanManageDirectMessages { get; init; }

    public string? CustomTitle { get; init; }
}

public sealed class ChatMemberBanned : ChatMember
{
    public override ChatMemberStatus Status => ChatMemberStatus.Kicked;

    public int UntilDate { get; init; }
}

public sealed class ChatMemberLeft : ChatMember
{
    public override ChatMemberStatus Status => ChatMemberStatus.Left;
}

public sealed class ChatMemberMember : ChatMember
{
    public override ChatMemberStatus Status => ChatMemberStatus.Member;

    public int? UntilDate { get; init; }
}

public sealed class ChatMemberOwner : ChatMember
{
    public override ChatMemberStatus Status => ChatMemberStatus.Creator;

    public bool IsAnonymous { get; init; }

    public string? CustomTitle { get; init; }
}

public sealed class ChatMemberRestricted : ChatMember
{
    public override ChatMemberStatus Status => ChatMemberStatus.Restricted;

    public bool IsMember { get; init; }

    public bool CanSendMessages { get; init; }

    public bool CanSendAudios { get; init; }

    public bool CanSendDocuments { get; init; }

    public bool CanSendPhotos { get; init; }

    public bool CanSendVideos { get; init; }

    public bool CanSendVideoNotes { get; init; }

    public bool CanSendVoiceNotes { get; init; }

    public bool CanSendPolls { get; init; }

    public bool CanSendOtherMessages { get; init; }

    public bool CanAddWebPagePreviews { get; init; }

    public bool CanChangeInfo { get; init; }

    public bool CanInviteUsers { get; init; }

    public bool CanPinMessages { get; init; }

    public bool CanManageTopics { get; init; }

    public int UntilDate { get; init; }
}
