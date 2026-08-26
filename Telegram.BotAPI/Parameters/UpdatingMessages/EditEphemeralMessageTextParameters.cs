using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class EditEphemeralMessageTextParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }

    public required long ReceiverUserId { get; init; }

    public required long EphemeralMessageId { get; init; }

    public required string Text { get; init; }

    public string? ParseMode { get; init; }

    public IReadOnlyList<MessageEntity>? Entities { get; init; }

    public InputRichMessage? RichMessage { get; init; }

    public LinkPreviewOptions? LinkPreviewOptions { get; init; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }
}
