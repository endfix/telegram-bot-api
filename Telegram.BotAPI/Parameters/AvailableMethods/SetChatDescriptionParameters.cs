namespace Telegram.BotAPI.Parameters;

public sealed class SetChatDescriptionParameters : ApiRequestParameters
{
    public object ChatId { set; get; }

    public string Description { set; get; }
}
