namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#chatjoinrequest
    public class ChatJoinRequest
    {
        public Chat Chat { get; set; }

        public User From { get; set; }

        public long UserChatId { get; set; }

        public int Date { get; set; }

        public string Bio { get; set; }

        public ChatInviteLink InviteLink { get; set; }
    }
}
