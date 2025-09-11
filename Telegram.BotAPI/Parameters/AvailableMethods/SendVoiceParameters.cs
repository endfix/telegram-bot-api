using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class SendVoiceParameters : ApiRequestParameters
{
    public string BusinessConnectionId { get; set; }

    public object ChatId { get; set; }

    public int MessageThreadId { get; set; }

    public int DirectMessagesTopicId { get; set; }

    public object Voice { get; set; }

    public string Caption { get; set; }

    public string ParseMode { get; set; }

    public MessageEntity[] CaptionEntities { get; set; }

    public int Duration { get; set; }

    public bool DisableNotification { get; set; }

    public bool ProtectContent { get; set; }

    public bool AllowPaidBroadcast { get; set; }

    public string MessageEffectId { get; set; }

    public SuggestedPostParameters SuggestedPostParameters { get; set; }

    public ReplyParameters ReplyParameters { get; set; }

    public ReplyMarkup ReplyMarkup { get; set; }
}
