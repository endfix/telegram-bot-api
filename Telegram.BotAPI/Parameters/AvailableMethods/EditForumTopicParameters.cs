namespace Telegram.BotAPI.Parameters;

public sealed class EditForumTopicParameters : ApiRequestParameters
{
    public object ChatId { get; set; }

    public int MessageThreadId { set; get; }

    public string Name { get; set; }

    public string IconCustomEmojiId { get; set; }
}
