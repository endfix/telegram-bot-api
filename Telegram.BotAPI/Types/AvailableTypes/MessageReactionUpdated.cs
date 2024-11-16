using System.Collections.Generic;

namespace Telegram.BotAPI.Types.AvailableTypes;

public sealed class MessageReactionUpdated
{
    public Chat Chat { get; set; }

    public int MessageId { get; set; }

    public User User { get; set; }

    public Chat ActorChat { get; set; }

    public int Date { get; set; }

    public List<ReactionType> OldReaction { get; set; }

    public List<ReactionType> NewReaction { get; set; }
}
