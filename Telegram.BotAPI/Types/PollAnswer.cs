using System.Collections.Generic;

namespace Telegram.BotAPI.Types
{
    // https://core.telegram.org/bots/api#pollanswer
    public class PollAnswer
    {
        public string PollId { get; set; }

        public Chat VoterChat { get; set; }

        public User User { get; set; }

        public List<int> OptionIds { get; set; }
    }
}
