using System.Collections.Generic;

namespace Telegram.BotAPI.Types
{
    // https://core.telegram.org/bots/api#polloption
    public class PollOption
    {
        public string Text { get; set; }

        public List<MessageEntity> TextEntities { get; set; }

        public int VoterCount { get; set; }
    }
}
