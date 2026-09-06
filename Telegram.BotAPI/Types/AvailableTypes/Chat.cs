using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents a Telegram chat.</summary>
public sealed class Chat
{
    /// <summary>Unique identifier for this chat.</summary>
    public required long Id { get; init; }

    /// <summary>The type of the chat.</summary>
    public required ChatTypes Type { get; init; }

    /// <summary>Title of the supergroup, channel or group chat, if available.</summary>
    public string? Title { get; init; }

    /// <summary>Username of the private chat, supergroup or channel, if available.</summary>
    public string? Username { get; init; }

    /// <summary>First name of the other party in a private chat, if available.</summary>
    public string? FirstName { get; init; }

    /// <summary>Last name of the other party in a private chat, if available.</summary>
    public string? LastName { get; init; }

    /// <summary>Indicates whether the supergroup chat is a forum with topics enabled.</summary>
    public bool? IsForum { get; init; }

    /// <summary>Indicates whether this chat is the direct messages chat of a channel.</summary>
    public bool? IsDirectMessages { get; init; }
}
