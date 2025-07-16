using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class SendDocumentParameters : ApiRequestParameters
{
    public string BusinessConnectionId { get; set; }

    public object ChatId { get; set; }

    public int MessageThreadId { get; set; }

    public object Document { get; set; }

    public object Thumbnail { get; set; }

    public string Caption { get; set; }

    public string ParseMode { get; set; }

    public MessageEntity[] CaptionEntities { get; set; }

    public bool DisableContentTypeDetection { get; set; }

    public bool DisableNotification { get; set; }

    public bool ProtectContent { get; set; }

    public string MessageEffectId { get; set; }

    public ReplyParameters ReplyParameters { get; set; }

    public ReplyMarkup ReplyMarkup { get; set; }
}
