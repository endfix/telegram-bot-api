using Telegram.BotAPI.Protocol;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class EditMessageReplyMarkupParameters : ApiRequestParameters
{
    public string? BusinessConnectionId { get; init; }

    public ChatIdSource? ChatId { get; init; }

    public long? MessageId { get; init; }

    public string? InlineMessageId { get; init; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }
}
