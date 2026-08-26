using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class EditEphemeralMessageReplyMarkupParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }

    public required long ReceiverUserId { get; init; }

    public required long EphemeralMessageId { get; init; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }
}
