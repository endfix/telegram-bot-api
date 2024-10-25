namespace Telegram.BotAPI.Types
{
    // https://core.telegram.org/bots/api#reactioncount
    public class ReactionCount
    {
        public ReactionType Type { get; set; }

        public int TotalCount { get; set; }
    }
}
