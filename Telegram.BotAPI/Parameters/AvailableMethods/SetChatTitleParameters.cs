namespace Telegram.BotAPI.Parameters;

public sealed class SetChatTitleParameters : ApiRequestParameters
{
    public object ChatId { set; get; }

    public string Title { set; get; }
}
