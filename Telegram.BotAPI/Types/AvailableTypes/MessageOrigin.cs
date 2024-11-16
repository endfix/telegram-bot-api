namespace Telegram.BotAPI.Types.AvailableTypes;

public abstract class MessageOrigin
{
    public abstract string Type { get; }

    public static class Types
    {
        public const string USER = "user";

        public const string HIDDEN_USER = "hidden_user";

        public const string CHAT = "chat";

        public const string CHANNEL = "channel";
    }
}

public sealed class MessageOriginChannel : MessageOrigin
{
    public override string Type => Types.CHANNEL;

    public int Date { get; set; }

    public Chat Chat { get; set; }

    public long MessageId { get; set; }

    public string AuthorSignature { get; set; }
}

public sealed class MessageOriginChat : MessageOrigin
{
    public override string Type => Types.CHAT;

    public int Date { get; set; }

    public Chat SenderChat { get; set; }

    public string AuthorSignature { get; set; }
}

public sealed class MessageOriginHiddenUser : MessageOrigin
{
    public override string Type => Types.HIDDEN_USER;

    public int Date { get; set; }

    public string SenderUserName { get; set; }
}

public sealed class MessageOriginUser : MessageOrigin
{
    public override string Type => Types.USER;

    public int Date { get; set; }

    public User SenderUser { get; set; }
}
