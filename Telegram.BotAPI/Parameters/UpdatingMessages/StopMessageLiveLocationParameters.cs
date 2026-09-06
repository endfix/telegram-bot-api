using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>stopMessageLiveLocation</c> method.
/// </summary>
public sealed class StopMessageLiveLocationParameters : ApiRequestParameters
{
    /// <summary>Unique identifier of the business connection.</summary>
    public string? BusinessConnectionId { get; init; }

    /// <summary>Chat containing the message.</summary>
    public ChatIdSource? ChatId { get; init; }

    /// <summary>Identifier of the message to edit.</summary>
    public long? MessageId { get; init; }

    /// <summary>Identifier of the inline message to edit.</summary>
    public string? InlineMessageId { get; init; }

    /// <summary>Replacement inline keyboard.</summary>
    public InlineKeyboardMarkup? ReplyMarkup { get; init; }
}
