using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class ForwardMessageParameters : ApiRequestParameters
{
    public object ChatId { get; set; }

    public int MessageThreadId { set; get; }

    public int DirectMessagesTopicId { get; set; }

    public object FromChatId { get; set; }

    public int VideoStartTimestamp { set; get; }

    public bool DisableNotification { get; set; }

    public bool ProtectContent { get; set; }

    public SuggestedPostParameters SuggestedPostParameters { get; set; }

    public int MessageId { set; get; }
}
