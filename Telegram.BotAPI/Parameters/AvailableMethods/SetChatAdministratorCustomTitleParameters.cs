namespace Telegram.BotAPI.Parameters;

public sealed class SetChatAdministratorCustomTitleParameters : ApiRequestParameters
{
    public object ChatId { get; set; }

    public long UserId { get; set; }

    public string CustomTitle { get; set; }
}
