using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Base type for information about a member's status in a chat.</summary>
public abstract class ChatMember
{
    /// <summary>Current status of the member in the chat.</summary>
    public abstract ChatMemberStatus Status { get; }

    /// <summary>Information about the user.</summary>
    public required virtual User User { get; init; }
}

/// <summary>Describes a chat administrator.</summary>
public sealed class ChatMemberAdministrator : ChatMember
{
    /// <summary>Gets the administrator status.</summary>
    public override ChatMemberStatus Status => ChatMemberStatus.Administrator;

    /// <summary>Indicates whether the bot can edit the administrator's privileges.</summary>
    public required bool CanBeEdited { get; init; }

    /// <summary>Indicates whether the administrator is anonymous.</summary>
    public required bool IsAnonymous { get; init; }

    /// <summary>Indicates whether the administrator can access the chat event log and manage chat settings.</summary>
    public required bool CanManageChat { get; init; }

    /// <summary>Indicates whether the administrator can delete messages.</summary>
    public required bool CanDeleteMessages { get; init; }

    /// <summary>Indicates whether the administrator can manage video chats.</summary>
    public required bool CanManageVideoChats { get; init; }

    /// <summary>Indicates whether the administrator can restrict, ban or unban members.</summary>
    public required bool CanRestrictMembers { get; init; }

    /// <summary>Indicates whether the administrator can add new administrators with a subset of their own privileges.</summary>
    public required bool CanPromoteMembers { get; init; }

    /// <summary>Indicates whether the administrator can change chat information.</summary>
    public required bool CanChangeInfo { get; init; }

    /// <summary>Indicates whether the administrator can invite new users to the chat.</summary>
    public required bool CanInviteUsers { get; init; }

    /// <summary>Indicates whether the administrator can post stories.</summary>
    public required bool CanPostStories { get; init; }

    /// <summary>Indicates whether the administrator can edit stories posted by other users.</summary>
    public required bool CanEditStories { get; init; }

    /// <summary>Indicates whether the administrator can delete stories posted by other users.</summary>
    public required bool CanDeleteStories { get; init; }

    /// <summary>Indicates whether the administrator can post messages in channels.</summary>
    public bool? CanPostMessages { get; init; }

    /// <summary>Indicates whether the administrator can edit messages of other users.</summary>
    public bool? CanEditMessages { get; init; }

    /// <summary>Indicates whether the administrator can pin messages.</summary>
    public bool? CanPinMessages { get; init; }

    /// <summary>Indicates whether the administrator can manage topics.</summary>
    public bool? CanManageTopics { get; init; }

    /// <summary>Indicates whether the administrator can manage direct messages.</summary>
    public bool? CanManageDirectMessages { get; init; }

    /// <summary>Indicates whether the administrator can manage tags.</summary>
    public bool? CanManageTags { get; init; }

    /// <summary>Indicates whether the administrator can send welcome messages.</summary>
    public bool? CanSendWelcomeMessages { get; init; }

    /// <summary>Custom title for the administrator, if available.</summary>
    public string? CustomTitle { get; init; }
}

/// <summary>Describes a member who was banned from the chat.</summary>
public sealed class ChatMemberBanned : ChatMember
{
    /// <summary>Gets the kicked status.</summary>
    public override ChatMemberStatus Status => ChatMemberStatus.Kicked;

    /// <summary>Date when the restriction will be lifted, in Unix time. Zero means forever.</summary>
    public required int UntilDate { get; init; }
}

/// <summary>Describes a user who is not a member of the chat.</summary>
public sealed class ChatMemberLeft : ChatMember
{
    /// <summary>Gets the left status.</summary>
    public override ChatMemberStatus Status => ChatMemberStatus.Left;
}

/// <summary>Describes a regular chat member.</summary>
public sealed class ChatMemberMember : ChatMember
{
    /// <summary>Gets the member status.</summary>
    public override ChatMemberStatus Status => ChatMemberStatus.Member;

    /// <summary>Custom tag of the member, if available.</summary>
    public string? Tag { get; init; }

    /// <summary>Date when the member's membership will expire, in Unix time, if available.</summary>
    public int? UntilDate { get; init; }
}

/// <summary>Describes the owner of a chat.</summary>
public sealed class ChatMemberOwner : ChatMember
{
    /// <summary>Gets the creator status.</summary>
    public override ChatMemberStatus Status => ChatMemberStatus.Creator;

    /// <summary>Indicates whether the owner is anonymous.</summary>
    public required bool IsAnonymous { get; init; }

    /// <summary>Custom title for the owner, if available.</summary>
    public string? CustomTitle { get; init; }
}

/// <summary>Describes a member with restricted permissions.</summary>
public sealed class ChatMemberRestricted : ChatMember
{
    /// <summary>Gets the restricted status.</summary>
    public override ChatMemberStatus Status => ChatMemberStatus.Restricted;

    /// <summary>Custom tag of the member, if available.</summary>
    public string? Tag { get; init; }

    /// <summary>Indicates whether the user is a member of the chat.</summary>
    public required bool IsMember { get; init; }

    /// <summary>Indicates whether the member can send text messages.</summary>
    public required bool CanSendMessages { get; init; }

    /// <summary>Indicates whether the member can send audios.</summary>
    public required bool CanSendAudios { get; init; }

    /// <summary>Indicates whether the member can send documents.</summary>
    public required bool CanSendDocuments { get; init; }

    /// <summary>Indicates whether the member can send photos.</summary>
    public required bool CanSendPhotos { get; init; }

    /// <summary>Indicates whether the member can send videos.</summary>
    public required bool CanSendVideos { get; init; }

    /// <summary>Indicates whether the member can send video notes.</summary>
    public required bool CanSendVideoNotes { get; init; }

    /// <summary>Indicates whether the member can send voice notes.</summary>
    public required bool CanSendVoiceNotes { get; init; }

    /// <summary>Indicates whether the member can send polls.</summary>
    public required bool CanSendPolls { get; init; }

    /// <summary>Indicates whether the member can send other messages.</summary>
    public required bool CanSendOtherMessages { get; init; }

    /// <summary>Indicates whether the member can add web page previews to messages.</summary>
    public required bool CanAddWebPagePreviews { get; init; }

    /// <summary>Indicates whether the member can change reactions to messages.</summary>
    public required bool CanReactToMessages { get; init; }

    /// <summary>Indicates whether the member can edit the chat tag.</summary>
    public required bool CanEditTag { get; init; }

    /// <summary>Indicates whether the member can change chat information.</summary>
    public required bool CanChangeInfo { get; init; }

    /// <summary>Indicates whether the member can invite new users to the chat.</summary>
    public required bool CanInviteUsers { get; init; }

    /// <summary>Indicates whether the member can pin messages.</summary>
    public required bool CanPinMessages { get; init; }

    /// <summary>Indicates whether the member can manage topics.</summary>
    public required bool CanManageTopics { get; init; }

    /// <summary>Date when the restrictions will be lifted, in Unix time. Zero means forever.</summary>
    public required int UntilDate { get; init; }
}
