using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class EditEphemeralMessageCaptionParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }

    public required long ReceiverUserId { get; init; }

    public required long EphemeralMessageId { get; init; }

    public string? Caption { get; init; }

    public string? ParseMode { get; init; }

    public IReadOnlyList<MessageEntity>? CaptionEntities { get; init; }

    public bool? ShowCaptionAboveMedia { get; init; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }
}
