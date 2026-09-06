using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents an incoming inline query.</summary>
public sealed class InlineQuery
{
    /// <summary>Unique identifier for this query.</summary>
    public required string Id { get; set; }

    /// <summary>Sender of the inline query.</summary>
    public required User From { get; set; }

    /// <summary>Text of the inline query.</summary>
    public required string Query { get; set; }

    /// <summary>Offset of the results to be returned, as supplied by Telegram.</summary>
    public required string Offset { get; set; }

    /// <summary>Type of the chat from which the inline query was sent, if available.</summary>
    public ChatTypes? ChatType { get; set; }

    /// <summary>Sender location, if the user has enabled location access for the bot.</summary>
    public Location? Location { get; set; }
}
