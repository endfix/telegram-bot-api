using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>editEphemeralMessageCaption</c> method.
/// </summary>
public sealed class EditEphemeralMessageCaptionParameters : ApiRequestParameters
{
    /// <summary>Chat containing the ephemeral message.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>Identifier of the user who received the message.</summary>
    public required long ReceiverUserId { get; init; }

    /// <summary>Identifier of the ephemeral message.</summary>
    public required long EphemeralMessageId { get; init; }

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
