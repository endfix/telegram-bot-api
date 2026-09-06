using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Contains information about a chat shared with the bot using a request-chat button.
/// </summary>
public sealed class ChatShared
{
    /// <summary>Identifier of the request.</summary>
    public required int RequestId { get; init; }

    /// <summary>Identifier of the shared chat.</summary>
    public required long ChatId { get; init; }

    /// <summary>Optional title of the chat, if the title was requested by the bot.</summary>
    public string? Title { get; init; }

    /// <summary>Optional username of the chat, if the username was requested by the bot and available.</summary>
    public string? Username { get; init; }

    /// <summary>Optional available sizes of the chat photo, if the photo was requested by the bot.</summary>
    public IReadOnlyList<PhotoSize>? Photo { get; init; }
}
