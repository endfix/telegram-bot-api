using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes the origin of a forwarded message.</summary>
public abstract class MessageOrigin
{
    /// <summary>Gets the origin kind.</summary>
    public abstract MessageOriginType Type { get; }
}

/// <summary>Describes a message originally sent to a channel chat.</summary>
public sealed class MessageOriginChannel : MessageOrigin
{
    /// <summary>Gets the channel origin kind.</summary>
    public override MessageOriginType Type => MessageOriginType.Channel;

    /// <summary>Original message date in Unix time.</summary>
    public required int Date { get; init; }

    /// <summary>Channel chat to which the message was originally sent.</summary>
    public required Chat Chat { get; init; }

    /// <summary>Unique identifier of the original message inside the channel.</summary>
    public required long MessageId { get; init; }

    /// <summary>Signature of the original post author, if available.</summary>
    public string? AuthorSignature { get; init; }
}

/// <summary>Describes a message originally sent on behalf of a chat to a group chat.</summary>
public sealed class MessageOriginChat : MessageOrigin
{
    /// <summary>Gets the chat origin kind.</summary>
    public override MessageOriginType Type => MessageOriginType.Chat;

    /// <summary>Original message date in Unix time.</summary>
    public required int Date { get; init; }

    /// <summary>Chat that originally sent the message.</summary>
    public required Chat SenderChat { get; init; }

    /// <summary>Original message author signature, if available.</summary>
    public string? AuthorSignature { get; init; }
}

/// <summary>Describes a message originally sent by an unknown user.</summary>
public sealed class MessageOriginHiddenUser : MessageOrigin
{
    /// <summary>Gets the hidden-user origin kind.</summary>
    public override MessageOriginType Type => MessageOriginType.HiddenUser;

    /// <summary>Original message date in Unix time.</summary>
    public required int Date { get; init; }

    /// <summary>Name of the user who originally sent the message.</summary>
    public required string SenderUserName { get; init; }
}

/// <summary>Describes a message originally sent by a known user.</summary>
public sealed class MessageOriginUser : MessageOrigin
{
    /// <summary>Gets the user origin kind.</summary>
    public override MessageOriginType Type => MessageOriginType.User;

    /// <summary>Original message date in Unix time.</summary>
    public required int Date { get; init; }

    /// <summary>User who originally sent the message.</summary>
    public required User SenderUser { get; init; }
}
