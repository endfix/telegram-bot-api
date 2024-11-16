namespace Telegram.BotAPI.Types.AvailableTypes;

public sealed class Chat
{
    public long Id { get; set; }

    public string Type { get; set; }

    public string Title { get; set; }

    public string Username { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public bool IsForum { get; set; }

    public static class Types
    {
        public const string SENDER = "sender";

        public const string PRIVATE = "private";

        public const string GROUP = "group";

        public const string SUPERGROUP = "supergroup";

        public const string CHANNEL = "channel";
    }
}
