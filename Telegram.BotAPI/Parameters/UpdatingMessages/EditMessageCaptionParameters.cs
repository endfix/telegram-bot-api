using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class EditMessageCaptionParameters : ApiRequestParameters
{
    public string? BusinessConnectionId { get; init; }

    public ChatIdSource? ChatId { get; init; }

    public long? MessageId { get; init; }

    public string? InlineMessageId { get; init; }

    public string? Caption { get; init; }

    public string? ParseMode { get; init; }

    public IReadOnlyList<MessageEntity>? CaptionEntities { get; init; }

    public bool? ShowCaptionAboveMedia { get; init; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }
}
