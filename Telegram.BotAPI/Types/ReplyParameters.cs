using System.Collections.Generic;

namespace Telegram.BotAPI.Types
{
    // https://core.telegram.org/bots/api#replyparameters
    public class ReplyParameters
    {
        public long MessageId { get; set; }

        public string ChatId { get; set; } = string.Empty;

        public bool AllowSendingWithoutReply { get; set; }

        public string Quote { get; set; } = string.Empty;

        public string QuoteParseMode { get; set; } = "HTML";

        public List<MessageEntity> QuoteEntities { get; set; }

        public int QuotePosition { get; set; }
    }
}
