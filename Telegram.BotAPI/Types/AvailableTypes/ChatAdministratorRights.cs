namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes administrator rights in a chat.</summary>
public sealed class ChatAdministratorRights
{
    /// <summary>Indicates whether the administrator is anonymous.</summary>
    public required bool IsAnonymous { get; init; }

    /// <summary>Indicates whether the administrator can access the chat event log, get boost list and view hidden members.</summary>
    public required bool CanManageChat { get; init; }

    /// <summary>Indicates whether the administrator can delete messages.</summary>
    public required bool CanDeleteMessages { get; init; }

    /// <summary>Indicates whether the administrator can manage video chats.</summary>
    public required bool CanManageVideoChats { get; init; }

    /// <summary>Indicates whether the administrator can restrict, ban or unban chat members.</summary>
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

    /// <summary>Indicates whether the administrator can edit messages of other users and pin messages.</summary>
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
}
