using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes an incoming query from a widget in a message sent by the bot or through the bot.
/// </summary>
/// <remarks>
/// Use <c>answerWidgetQuery</c> to answer the query. Each user can send at most 5 queries per
/// 5 seconds to the bot from all their widgets.
/// </remarks>
public sealed class WidgetQuery
{
    /// <summary>Unique identifier of the query.</summary>
    public required string Id { get; init; }

    /// <summary>Sender.</summary>
    public required User From { get; init; }

    /// <summary>Chat containing the message with the widget; omitted for inline messages.</summary>
    public Chat? Chat { get; init; }

    /// <summary>
    /// Identifier of the message containing the widget; omitted for inline messages.
    /// </summary>
    public long? MessageId { get; init; }

    /// <summary>Identifier of the inline message containing the widget.</summary>
    public string? InlineMessageId { get; init; }

    /// <summary>
    /// Global identifier of the chat to which the message with the widget was sent.
    /// </summary>
    public required string ChatInstance { get; init; }

    /// <summary>
    /// For widgets in inline messages, the chat type. One of <c>sender</c>, <c>private</c>,
    /// <c>group</c>, <c>supergroup</c>, or <c>channel</c>.
    /// </summary>
    public ChatTypes? ChatType { get; init; }

    /// <summary>Type of the query.</summary>
    public required WidgetQueryType Type { get; init; }

    /// <summary>Query data, from 1 through 64 bytes.</summary>
    public required string Data { get; init; }

    /// <summary>
    /// Unique identifier of the shared widget that sent the query; omitted if the widget is not
    /// shared.
    /// </summary>
    public string? WidgetId { get; init; }
}
