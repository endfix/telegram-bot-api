using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class EditMessageReplyMarkupParameters : ApiRequestParameters
{
    public string? BusinessConnectionId { get; init; }

    public ChatIdSource? ChatId { get; init; }

    public long? MessageId { get; init; }

    public string? InlineMessageId { get; init; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }
}
