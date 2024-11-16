using System.Collections.Generic;

namespace Telegram.BotAPI.Types.AvailableTypes;

public sealed class MessageReactionCountUpdated
{
    public Chat Chat { get; set; }

    public int MessageId { get; set; }

    public int Date { get; set; }

    public List<ReactionCount> Reactions { get; set; }
}
