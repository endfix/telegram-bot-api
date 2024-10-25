namespace Telegram.BotAPI.Types;

// https://core.telegram.org/bots/api#messageorigin
public abstract class MessageOrigin
{
    public virtual string Type { get; set; }

    public static class Types
    {
        public const string USER = "user";

        public const string HIDDEN_USER = "hidden_user";

        public const string CHAT = "chat";

        public const string CHANNEL = "channel";
    }
}

// https://core.telegram.org/bots/api#messageoriginchannel
public sealed class MessageOriginChannel : MessageOrigin
{
    public override string Type => Types.CHANNEL;

    public int Date { get; set; }

    public Chat Chat { get; set; }

    public long MessageId { get; set; }

    public string AuthorSignature { get; set; }
}

// https://core.telegram.org/bots/api#messageoriginchat
public sealed class MessageOriginChat : MessageOrigin
{
    public override string Type => Types.CHAT;

    public int Date { get; set; }

    public Chat SenderChat { get; set; }

    public string AuthorSignature { get; set; }
}

// https://core.telegram.org/bots/api#messageoriginhiddenuser
public sealed class MessageOriginHiddenUser : MessageOrigin
{
    public override string Type => Types.HIDDEN_USER;

    public int Date { get; set; }

    public string SenderUserName { get; set; }
}

// https://core.telegram.org/bots/api#messageoriginuser
public sealed class MessageOriginUser : MessageOrigin
{
    public override string Type => Types.USER;

    public int Date { get; set; }

    public User SenderUser { get; set; }
}
