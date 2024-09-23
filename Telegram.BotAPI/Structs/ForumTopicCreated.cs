namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#forumtopiccreated
    public class ForumTopicCreated
    {
        public string Name { get; set; }

        public int IconColor { get; set; }

        public string IconCustomEmojiId { get; set; }
    }
}
