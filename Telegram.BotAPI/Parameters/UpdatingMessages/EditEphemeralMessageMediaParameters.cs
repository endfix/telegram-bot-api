using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>editEphemeralMessageMedia</c> method.
/// </summary>
public sealed class EditEphemeralMessageMediaParameters : ApiRequestParameters
{
    /// <summary>Chat containing the ephemeral message.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>Identifier of the user who received the message.</summary>
    public required long ReceiverUserId { get; init; }

    /// <summary>Identifier of the ephemeral message.</summary>
    public required long EphemeralMessageId { get; init; }

    /// <summary>New media content.</summary>
    public required InputMedia Media { get; init; }

    /// <summary>Inline keyboard attached to the message.</summary>
    public InlineKeyboardMarkup? ReplyMarkup { get; init; }
}
