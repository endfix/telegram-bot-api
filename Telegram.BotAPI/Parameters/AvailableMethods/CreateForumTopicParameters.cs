namespace Telegram.BotAPI.Parameters;

public sealed class CreateForumTopicParameters : ApiRequestParameters
{
    public object ChatId { get; set; }

    public string Name { get; set; }

    public int IconColor { get; set; }

    public string IconCustomEmojiId { get; set; }
}
