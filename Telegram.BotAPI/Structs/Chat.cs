namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#chat
    public class Chat
    {
        public long Id { get; set; }

        public string Type { get; set; }

        public string Title { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsForum { get; set; }
    }
}
