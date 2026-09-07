namespace Endfix.Telegram.BotAPI.Enums;

/// <summary>Identifies a chat member's membership and permission status.</summary>
public enum ChatMemberStatus
{
    /// <summary>The member owns the chat.</summary>
    Creator,

    /// <summary>The member is a chat administrator.</summary>
    Administrator,

    /// <summary>The user is a regular chat member.</summary>
    Member,

    /// <summary>The user is a member with restricted permissions.</summary>
    Restricted,

    /// <summary>The user is not currently a member of the chat.</summary>
    Left,

    /// <summary>The user was banned from the chat.</summary>
    Kicked
}
