using System.Collections.Generic;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class EditMessageTextParameters : ApiRequestParameters
{
    public string? BusinessConnectionId { get; init; }

    public ChatIdSource? ChatId { get; init; }

    public long? MessageId { get; init; }

    public string? InlineMessageId { get; init; }

    public required string Text { get; init; }

    public string? ParseMode { get; init; }

    public IReadOnlyList<MessageEntity>? Entities { get; init; }

    public LinkPreviewOptions? LinkPreviewOptions { get; init; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }
}
