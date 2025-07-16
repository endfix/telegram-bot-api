using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class EditMessageCaptionParameters : ApiRequestParameters
{
    public string BusinessConnectionId { get; set; }

    public object ChatId { get; set; }

    public int MessageId { get; set; }

    public string InlineMessageId { get; set; }

    public string Caption { get; set; }

    public string ParseMode { get; set; }

    public MessageEntity[] CaptionEntities { get; set; }

    public bool ShowCaptionAboveMedia { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }
}
