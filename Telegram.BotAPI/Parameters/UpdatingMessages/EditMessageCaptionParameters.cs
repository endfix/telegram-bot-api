using System.Collections.Generic;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class EditMessageCaptionParameters : ApiRequestParameters
{
    public string? BusinessConnectionId { get; init; }

    public object? ChatId { get; init; }

    public int? MessageId { get; init; }

    public string? InlineMessageId { get; init; }

    public string? Caption { get; init; }

    public string? ParseMode { get; init; }

    public IReadOnlyList<MessageEntity>? CaptionEntities { get; init; }

    public bool? ShowCaptionAboveMedia { get; init; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }
}
