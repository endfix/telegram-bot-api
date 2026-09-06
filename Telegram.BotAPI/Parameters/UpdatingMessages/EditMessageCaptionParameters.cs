using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>editMessageCaption</c> method.
/// </summary>
public sealed class EditMessageCaptionParameters : ApiRequestParameters
{
    /// <summary>Unique identifier of the business connection.</summary>
    public string? BusinessConnectionId { get; init; }

    /// <summary>Chat containing the message.</summary>
    public ChatIdSource? ChatId { get; init; }

    /// <summary>Identifier of the message to edit.</summary>
    public long? MessageId { get; init; }

    /// <summary>Identifier of the inline message to edit.</summary>
    public string? InlineMessageId { get; init; }

    /// <summary>New caption of the message.</summary>
    public string? Caption { get; init; }

    /// <summary>Mode for parsing entities in the caption.</summary>
    public string? ParseMode { get; init; }

    /// <summary>Explicit entities in the caption.</summary>
    public IReadOnlyList<MessageEntity>? CaptionEntities { get; init; }

    /// <summary>Whether to show the caption above the media.</summary>
    public bool? ShowCaptionAboveMedia { get; init; }

    /// <summary>Inline keyboard attached to the message.</summary>
    public InlineKeyboardMarkup? ReplyMarkup { get; init; }
}
