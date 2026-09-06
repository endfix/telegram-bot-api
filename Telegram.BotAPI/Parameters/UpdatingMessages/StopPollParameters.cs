using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>stopPoll</c> method.
/// </summary>
public sealed class StopPollParameters : ApiRequestParameters
{
    /// <summary>Unique identifier of the business connection.</summary>
    public string? BusinessConnectionId { get; init; }

    /// <summary>Chat containing the poll.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>Identifier of the poll message.</summary>
    public required long MessageId { get; init; }

    /// <summary>Replacement inline keyboard.</summary>
    public InlineKeyboardMarkup? ReplyMarkup { get; init; }
}
