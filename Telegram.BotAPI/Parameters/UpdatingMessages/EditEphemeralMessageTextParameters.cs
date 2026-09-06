using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>editEphemeralMessageText</c> method.
/// </summary>
public sealed class EditEphemeralMessageTextParameters : ApiRequestParameters
{
    /// <summary>Chat containing the ephemeral message.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>Identifier of the user who received the message.</summary>
    public required long ReceiverUserId { get; init; }

    /// <summary>Identifier of the ephemeral message.</summary>
    public required long EphemeralMessageId { get; init; }

    /// <summary>New text of the message.</summary>
    public required string Text { get; init; }

    /// <summary>Mode for parsing entities in the message text.</summary>
    public string? ParseMode { get; init; }

    /// <summary>Explicit entities in the message text.</summary>
    public IReadOnlyList<MessageEntity>? Entities { get; init; }

    /// <summary>Rich message content attached to the text.</summary>
    public InputRichMessage? RichMessage { get; init; }

    /// <summary>Options for the link preview.</summary>
    public LinkPreviewOptions? LinkPreviewOptions { get; init; }

    /// <summary>Inline keyboard attached to the message.</summary>
    public InlineKeyboardMarkup? ReplyMarkup { get; init; }
}
