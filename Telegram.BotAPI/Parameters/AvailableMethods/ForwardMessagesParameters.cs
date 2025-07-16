namespace Telegram.BotAPI.Parameters;

public sealed class ForwardMessagesParameters : ApiRequestParameters
{
    public object ChatId { set; get; }

    public int MessageThreadId { set; get; }

    public object FromChatId { get; set; }

    public int[] MessageIds { get; set; }

    public bool DisableNotification { get; set; }

    public bool ProtectContent { get; set; }
}
