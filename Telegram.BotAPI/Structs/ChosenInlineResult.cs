namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#choseninlineresult
    public class ChosenInlineResult
    {
        public string ResultId { get; set; }

        public User From { get; set; }

        public Location Location { get; set; }

        public string InlineMessageId { get; set; }

        public string Query { get; set; }
    }
}
