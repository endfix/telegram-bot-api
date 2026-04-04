using System.Collections.Generic;

namespace Telegram.BotAPI.Types;

public sealed class MessageReactionUpdated
{
    public required Chat Chat { get; init; }

    public required long MessageId { get; init; }

    public User? User { get; init; }

    public Chat? ActorChat { get; init; }

    public required long Date { get; init; }

    public required IReadOnlyList<ReactionType> OldReaction { get; init; }

    public required IReadOnlyList<ReactionType> NewReaction { get; init; }
}
