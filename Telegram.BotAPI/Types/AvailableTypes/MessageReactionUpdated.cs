namespace Telegram.BotAPI.Types;

public sealed class MessageReactionUpdated
{
    public required Chat Chat { get; init; }

    public required int MessageId { get; init; }

    public User? User { get; init; }

    public Chat? ActorChat { get; init; }

    public required int Date { get; init; }

    public required ReactionType[] OldReaction { get; init; }

    public required ReactionType[] NewReaction { get; init; }
}
