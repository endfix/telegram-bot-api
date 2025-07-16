using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class EditMessageMediaParameters : ApiRequestParameters
{
    public string BusinessConnectionId { get; set; }

    public object ChatId { get; set; }

    public int MessageId { get; set; }

    public string InlineMessageId { get; set; }

    public InputMedia Media { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }
}
