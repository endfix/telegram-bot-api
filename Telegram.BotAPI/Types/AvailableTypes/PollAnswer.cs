using System.Collections.Generic;

namespace Telegram.BotAPI.Types.AvailableTypes;

public sealed class PollAnswer
{
    public string PollId { get; set; }

    public Chat VoterChat { get; set; }

    public User User { get; set; }

    public List<int> OptionIds { get; set; }
}
