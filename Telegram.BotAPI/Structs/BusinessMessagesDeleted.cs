namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#businessmessagesdeleted
    public class BusinessMessagesDeleted
    {
        public string BusinessConnectionId { get; set; }

        public Chat Chat { get; set; }

        public List<int> MessageIds { get; set; }
    }
}
