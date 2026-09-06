using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>editMessageMedia</c> method.
/// </summary>
public sealed class EditMessageMediaParameters : ApiRequestParameters
{
    /// <summary>Unique identifier of the business connection.</summary>
    public string? BusinessConnectionId { get; init; }

    /// <summary>Chat containing the message.</summary>
    public ChatIdSource? ChatId { get; init; }

    /// <summary>Identifier of the message to edit.</summary>
    public long? MessageId { get; init; }

    /// <summary>Identifier of the inline message to edit.</summary>
    public string? InlineMessageId { get; init; }

    /// <summary>New media content.</summary>
    public required InputMedia Media { get; init; }

    /// <summary>Inline keyboard attached to the message.</summary>
    public InlineKeyboardMarkup? ReplyMarkup { get; init; }
}
