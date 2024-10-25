namespace Telegram.BotAPI.Types;

// https://core.telegram.org/bots/api#forumtopiccreated
public sealed class ForumTopicCreated
{
    public string Name { get; set; }

    public int IconColor { get; set; }

    public string IconCustomEmojiId { get; set; }
}
