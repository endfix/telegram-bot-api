namespace Telegram.BotAPI.Types;

public sealed class PollAnswer
{
    public string PollId { get; set; }

    public Chat VoterChat { get; set; }

    public User User { get; set; }

    public int[] OptionIds { get; set; }
}
