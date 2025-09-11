using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class SendMessageParameters : ApiRequestParameters
{
    public string BusinessConnectionId { get; set; }

    public object ChatId { get; set; }

    public int MessageThreadId { get; set; }

    public int DirectMessagesTopicId { get; set; }

    public string Text { get; set; }

    public string ParseMode { get; set; }

    public MessageEntity[] Entities { get; set; }

    public LinkPreviewOptions LinkPreviewOptions { get; set; }

    public bool DisableNotification { get; set; }

    public bool ProtectContent { get; set; }

    public bool AllowPaidBroadcast { get; set; }

    public string MessageEffectId { get; set; }

    public SuggestedPostParameters SuggestedPostParameters { get; set; }

    public ReplyParameters ReplyParameters { get; set; }

    public ReplyMarkup ReplyMarkup { get; set; }
}