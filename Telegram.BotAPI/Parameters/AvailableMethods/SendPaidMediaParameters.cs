using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class SendPaidMediaParameters : ApiRequestParameters
{
    public string BusinessConnectionId { get; set; }

    public object ChatId { get; set; }

    public int StarCount { get; set; }

    public InputPaidMedia[] Media { get; set; }

    public string Payload { get; set; }

    public string Caption { get; set; }

    public string ParseMode { get; set; }

    public MessageEntity[] CaptionEntities { get; set; }

    public bool ShowCaptionAboveMedia { get; set; }

    public bool DisableNotification { get; set; }

    public bool ProtectContent { get; set; }

    public ReplyParameters ReplyParameters { get; set; }

    public ReplyMarkup ReplyMarkup { get; set; }
}
