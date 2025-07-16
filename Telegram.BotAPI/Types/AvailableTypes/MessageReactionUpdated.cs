namespace Telegram.BotAPI.Types;

public sealed class MessageReactionUpdated
{
    public Chat Chat { get; set; }

    public int MessageId { get; set; }

    public User User { get; set; }

    public Chat ActorChat { get; set; }

    public int Date { get; set; }

    public ReactionType[] OldReaction { get; set; }

    public ReactionType[] NewReaction { get; set; }
}
