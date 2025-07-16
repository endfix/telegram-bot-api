namespace Telegram.BotAPI.Parameters;

public sealed class PinChatMessageParameters : ApiRequestParameters
{
    public string BusinessConnectionId { set; get; }

    public object ChatId { get; set; }

    public int MessageId { set; get; }

    public bool DisableNotification { set; get; }
}
