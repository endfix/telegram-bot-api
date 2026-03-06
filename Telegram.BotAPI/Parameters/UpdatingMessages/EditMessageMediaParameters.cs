using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class EditMessageMediaParameters : ApiRequestParameters
{
    public string? BusinessConnectionId { get; init; }

    public object? ChatId { get; init; }

    public int? MessageId { get; init; }

    public string? InlineMessageId { get; init; }

    public required InputMedia Media { get; init; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }
}
