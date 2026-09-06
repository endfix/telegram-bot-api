namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents a request to join a chat.</summary>
public sealed class ChatJoinRequest
{
    /// <summary>Chat to which the user requested to join.</summary>
    public required Chat Chat { get; set; }

    /// <summary>User who requested to join.</summary>
    public required User From { get; set; }

    /// <summary>Identifier of the private chat with the user.</summary>
    public required long UserChatId { get; set; }

    /// <summary>Date when the request was sent, in Unix time.</summary>
    public required int Date { get; set; }

    /// <summary>Bio of the user, if available.</summary>
    public string? Bio { get; set; }

    /// <summary>Invite link used by the user to join the chat, if available.</summary>
    public ChatInviteLink? InviteLink { get; set; }

    /// <summary>Identifier of the join request query, if available.</summary>
    public string? QueryId { get; set; }
}
