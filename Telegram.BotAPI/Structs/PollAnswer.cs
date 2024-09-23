namespace Telegram.BotAPI.Structs
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
