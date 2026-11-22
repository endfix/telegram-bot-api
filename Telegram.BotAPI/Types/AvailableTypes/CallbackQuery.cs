namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents an incoming callback query from a callback button in an inline keyboard or a rich message.</summary>
public sealed class CallbackQuery
{
    /// <summary>Unique identifier for this query.</summary>
    public required string Id { get; init; }

    /// <summary>User who sent the callback query.</summary>
    public required User From { get; init; }

    /// <summary>Message with the callback button that originated the query, if available.</summary>
    public MaybeInaccessibleMessage? Message { get; init; }

    /// <summary>
    /// Identifier of the message sent via the bot in inline mode that originated
    /// the query. Also present for messages sent by the bot, depending on the
    /// <c>callback_query_mode</c> parameter of <c>setMySettings</c>.
    /// </summary>
    public string? InlineMessageId { get; init; }

    /// <summary>Global identifier that uniquely identifies the chat where the query originated.</summary>
    public required string ChatInstance { get; init; }

    /// <summary>Data associated with the callback button, if available.</summary>
    public string? Data { get; init; }

    /// <summary>Short name of the game that was requested, if the button was a game button.</summary>
    public string? GameShortName { get; init; }
}
