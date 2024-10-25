using System.Collections.Generic;

namespace Telegram.BotAPI.Types
{
    // https://core.telegram.org/bots/api#messagereactioncountupdated
    public class MessageReactionCountUpdated
    {
        public Chat Chat { get; set; }

        public int MessageId { get; set; }

        public int Date { get; set; }

        public List<ReactionCount> Reactions { get; set; }
    }
}
