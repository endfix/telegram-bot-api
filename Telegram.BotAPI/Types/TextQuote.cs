using System.Collections.Generic;

namespace Telegram.BotAPI.Types
{
    // https://core.telegram.org/bots/api#textquote
    public class TextQuote
    {
        public string Text { get; set; }

        public List<MessageEntity> Entities { get; set; }

        public int Position { get; set; }

        public bool IsManual { get; set; }
    }
}
