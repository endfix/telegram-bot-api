using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>editMessageText</c> method.
/// </summary>
public sealed class EditMessageTextParameters : ApiRequestParameters
{
    /// <summary>Unique identifier of the business connection.</summary>
    public string? BusinessConnectionId { get; init; }

    /// <summary>Chat containing the message.</summary>
    public ChatIdSource? ChatId { get; init; }

    /// <summary>Identifier of the message to edit.</summary>
    public long? MessageId { get; init; }

    /// <summary>Identifier of the inline message to edit.</summary>
    public string? InlineMessageId { get; init; }

    /// <summary>New text of the message.</summary>
    public required string Text { get; init; }

    /// <summary>Mode for parsing entities in the message text.</summary>
    public string? ParseMode { get; init; }

    /// <summary>Explicit entities in the message text.</summary>
    public IReadOnlyList<MessageEntity>? Entities { get; init; }

    /// <summary>Options for the link preview.</summary>
    public LinkPreviewOptions? LinkPreviewOptions { get; init; }

    /// <summary>Rich message content attached to the text.</summary>
    public InputRichMessage? RichMessage { get; init; }

    /// <summary>Inline keyboard attached to the message.</summary>
    public InlineKeyboardMarkup? ReplyMarkup { get; init; }
}
