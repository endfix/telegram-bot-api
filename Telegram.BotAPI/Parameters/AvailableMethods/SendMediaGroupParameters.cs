using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class SendMediaGroupParameters : ApiRequestParameters
{
    public string BusinessConnectionId { get; set; }

    public object ChatId { get; set; }

    public int MessageThreadId { get; set; }

    public int DirectMessagesTopicId { get; set; }

    public InputMedia[] Media { get; set; }

    public bool DisableNotification { get; set; }

    public bool ProtectContent { get; set; }

    public bool AllowPaidBroadcast { get; set; }

    public string MessageEffectId { get; set; }

    public ReplyParameters ReplyParameters { get; set; }
}
