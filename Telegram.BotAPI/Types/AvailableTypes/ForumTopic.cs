namespace Telegram.BotAPI.Types.AvailableTypes;
public sealed class ForumTopic
{
    public int MessageThreadId { get; set; }

    public string Name { get; set; }

    public int IconColor { get; set; }

    public string IconCustomEmojiId { get; set; }
}
