namespace Telegram.BotAPI.Parameters;

public sealed class EditGeneralForumTopicParameters : ApiRequestParameters
{
    public object ChatId { get; set; }

    public string Name { get; set; }
}
