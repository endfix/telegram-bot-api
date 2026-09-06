namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents a change in a chat member's status or privileges.</summary>
public sealed class ChatMemberUpdated
{
    /// <summary>Chat in which the change occurred.</summary>
    public required Chat Chat { get; init; }

    /// <summary>User who performed the change.</summary>
    public required User From { get; init; }

    /// <summary>Date when the change occurred, in Unix time.</summary>
    public required int Date { get; init; }

    /// <summary>Member information before the change.</summary>
    public required ChatMember OldChatMember { get; init; }

    /// <summary>Member information after the change.</summary>
    public required ChatMember NewChatMember { get; init; }

    /// <summary>Invite link that was used by the user to join the chat, if available.</summary>
    public ChatInviteLink? InviteLink { get; init; }

    /// <summary>Indicates whether the user joined the chat through a join request.</summary>
    public bool? ViaJoinRequest { get; init; }

    /// <summary>Indicates whether the user joined the chat through a chat folder invite link.</summary>
    public bool? ViaChatFolderInviteLink { get; init; }
}
