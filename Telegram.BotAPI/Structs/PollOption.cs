namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#polloption
    public class PollOption
    {
        public string Text { get; set; }

        public List<MessageEntity> TextEntities { get; set; }

        public int VoterCount { get; set; }
    }
}
