using Telegram.BotAPI.Protocol;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class EditEphemeralMessageMediaParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }

    public required long ReceiverUserId { get; init; }

    public required long EphemeralMessageId { get; init; }

    public required InputMedia Media { get; init; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }
}
