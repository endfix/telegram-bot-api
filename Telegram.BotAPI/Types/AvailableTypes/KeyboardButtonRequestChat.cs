namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes which chat may be selected using a keyboard button.</summary>
public sealed class KeyboardButtonRequestChat
{
    /// <summary>Identifier of the request.</summary>
    public required int RequestId { get; init; }

    /// <summary>Restricts selection to channel chats.</summary>
    public required bool ChatIsChannel { get; init; }

    /// <summary>Restricts selection to forum supergroups when set.</summary>
    public bool? ChatIsForum { get; init; }

    /// <summary>Restricts selection based on whether the chat has a username.</summary>
    public bool? ChatHasUsername { get; init; }

    /// <summary>Restricts selection based on whether the chat was created by the user.</summary>
    public bool? ChatIsCreated { get; init; }

    /// <summary>Required administrator rights of the selecting user, if any.</summary>
    public ChatAdministratorRights? UserAdministratorRights { get; init; }

    /// <summary>Required administrator rights of the bot in the selected chat, if any.</summary>
    public ChatAdministratorRights? BotAdministratorRights { get; init; }

    /// <summary>Indicates whether the bot must already be a member of the selected chat.</summary>
    public bool? BotIsMember { get; init; }

    /// <summary>Requests the selected chat title.</summary>
    public bool? RequestTitle { get; init; }

    /// <summary>Requests the selected chat username.</summary>
    public bool? RequestUsername { get; init; }

    /// <summary>Requests the selected chat photo.</summary>
    public bool? RequestPhoto { get; init; }
}
