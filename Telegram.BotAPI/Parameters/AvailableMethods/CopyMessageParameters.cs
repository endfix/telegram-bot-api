using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class CopyMessageParameters : ApiRequestParameters
{
    public object ChatId { set; get; }

    public int MessageThreadId { get; set; }

    public int DirectMessagesTopicId { get; set; }

    public object FromChatId { get; set; }

    public int MessageId { get; set; }

    public int VideoStartTimestamp { set; get; }

    public string Caption { get; set; }

    public string ParseMode { get; set; }

    public MessageEntity[] CaptionEntities { get; set; }

    public bool ShowCaptionAboveMedia { get; set; }

    public bool DisableNotification { get; set; }

    public bool ProtectContent { get; set; }

    public bool AllowPaidBroadcast { get; set; }

    public SuggestedPostParameters SuggestedPostParameters { get; set; }

    public ReplyParameters ReplyParameters { get; set; }

    public ReplyMarkup ReplyMarkup { get; set; }
}
