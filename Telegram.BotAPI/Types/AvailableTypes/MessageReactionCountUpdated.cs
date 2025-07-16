namespace Telegram.BotAPI.Types;

public sealed class MessageReactionCountUpdated
{
    public Chat Chat { get; set; }

    public int MessageId { get; set; }

    public int Date { get; set; }

    public ReactionCount[] Reactions { get; set; }
}
