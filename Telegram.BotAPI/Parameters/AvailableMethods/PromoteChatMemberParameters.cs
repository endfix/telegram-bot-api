using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>promoteChatMember</c> method.
/// </summary>
public sealed class PromoteChatMemberParameters : ApiRequestParameters
{
    /// <summary>Target supergroup or channel identifier or channel username.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>Target user identifier.</summary>
    public required long UserId { get; init; }

    /// <summary>Whether the administrator's presence in the chat is hidden.</summary>
    public bool? IsAnonymous { get; init; }

    /// <summary>Whether the administrator can access management features. This privilege is implied by any other administrator privilege.</summary>
    public bool? CanManageChat { get; init; }

    /// <summary>Whether the administrator can delete messages from other users.</summary>
    public bool? CanDeleteMessages { get; init; }

    /// <summary>Whether the administrator can manage video chats.</summary>
    public bool? CanManageVideoChats { get; init; }

    /// <summary>Whether the administrator can restrict, ban or unban members, or access supergroup statistics.</summary>
    public bool? CanRestrictMembers { get; init; }

    /// <summary>Whether the administrator can add administrators with a subset of their privileges and demote administrators they promoted.</summary>
    public bool? CanPromoteMembers { get; init; }

    /// <summary>Whether the administrator can change the chat title, photo and other settings.</summary>
    public bool? CanChangeInfo { get; init; }

    /// <summary>Whether the administrator can invite users.</summary>
    public bool? CanInviteUsers { get; init; }

    /// <summary>Whether the administrator can post stories to the chat.</summary>
    public bool? CanPostStories { get; init; }

    /// <summary>Whether the administrator can edit stories posted by others, post stories, pin stories and access the story archive.</summary>
    public bool? CanEditStories { get; init; }

    /// <summary>Whether the administrator can delete stories posted by others.</summary>
    public bool? CanDeleteStories { get; init; }

    /// <summary>Whether the administrator can post in the channel, approve suggested posts or access channel statistics; for channels only.</summary>
    public bool? CanPostMessages { get; init; }

    /// <summary>Whether the administrator can edit messages from other users and pin messages; for channels only.</summary>
    public bool? CanEditMessages { get; init; }

    /// <summary>Whether the administrator can pin messages; for supergroups only.</summary>
    public bool? CanPinMessages { get; init; }

    /// <summary>Whether the administrator can create, rename, close and reopen forum topics; for supergroups only.</summary>
    public bool? CanManageTopics { get; init; }

    /// <summary>Whether the administrator can manage channel direct messages and decline suggested posts; for channels only.</summary>
    public bool? CanManageDirectMessages { get; init; }

    /// <summary>Whether the administrator can edit tags of regular members; for groups and supergroups only.</summary>
    public bool? CanManageTags { get; init; }

    /// <summary>Whether the administrator can manage welcome messages or, for bots, send them directly.</summary>
    public bool? CanSendWelcomeMessages { get; init; }
}
