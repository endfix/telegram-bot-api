namespace Telegram.BotAPI.Types;

public sealed class ForumTopicCreated
{
    public string Name { get; set; }

    public int IconColor { get; set; }

    public string IconCustomEmojiId { get; set; }

    public bool IsNameImplicit { get; set; }
}
