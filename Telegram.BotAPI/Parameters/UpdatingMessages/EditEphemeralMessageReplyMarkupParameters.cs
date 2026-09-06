using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>editEphemeralMessageReplyMarkup</c> method.
/// </summary>
public sealed class EditEphemeralMessageReplyMarkupParameters : ApiRequestParameters
{
    /// <summary>Chat containing the ephemeral message.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>Identifier of the user who received the message.</summary>
    public required long ReceiverUserId { get; init; }

    /// <summary>Identifier of the ephemeral message.</summary>
    public required long EphemeralMessageId { get; init; }

    /// <summary>Replacement inline keyboard.</summary>
    public InlineKeyboardMarkup? ReplyMarkup { get; init; }
}
