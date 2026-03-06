using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class StopMessageLiveLocationParameters : ApiRequestParameters
{
    public string? BusinessConnectionId { get; init; }

    public object? ChatId { get; init; }

    public long? MessageId { get; init; }

    public string? InlineMessageId { get; init; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }
}
