using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class EditMessageTextParameters : ApiRequestParameters
{
    public string BusinessConnectionId { get; set; }

    public object ChatId { get; set; }

    public int MessageId { get; set; }

    public string InlineMessageId { get; set; }

    public string Text { get; set; }

    public string ParseMode { get; set; }

    public MessageEntity[] Entities { get; set; }

    public LinkPreviewOptions LinkPreviewOptions { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }
}
