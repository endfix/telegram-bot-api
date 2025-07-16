namespace Telegram.BotAPI.Parameters;

public sealed class CopyMessagesParameters : ApiRequestParameters
{
    public object ChatId { set; get; }

    public int MessageThreadId { get; set; }

    public object FromChatId { get; set; }

    public int[] MessageIds { get; set; }

    public bool DisableNotification { get; set; }

    public bool ProtectContent { get; set; }

    public bool RemoveCaption { get; set; }
}
