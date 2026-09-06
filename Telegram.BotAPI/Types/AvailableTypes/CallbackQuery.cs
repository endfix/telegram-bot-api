namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents an incoming callback query from an inline keyboard button.</summary>
public sealed class CallbackQuery
{
    /// <summary>Unique identifier for this query.</summary>
    public required string Id { get; init; }

    /// <summary>User who sent the callback query.</summary>
    public required User From { get; init; }

    /// <summary>Message with the callback button that originated the query, if available.</summary>
    public MaybeInaccessibleMessage? Message { get; init; }

    /// <summary>Identifier of the message that contains the callback button, if the message was sent using inline mode.</summary>
    public string? InlineMessageId { get; init; }

    /// <summary>Global identifier that uniquely identifies the chat where the query originated.</summary>
    public required string ChatInstance { get; init; }

    /// <summary>Data associated with the callback button, if available.</summary>
    public string? Data { get; init; }

    /// <summary>Short name of the game that was requested, if the button was a game button.</summary>
    public string? GameShortName { get; init; }
}
