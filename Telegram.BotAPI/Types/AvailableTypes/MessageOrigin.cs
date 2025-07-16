using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public abstract class MessageOrigin
{
    public abstract MessageOriginTypes Type { get; }
}

public sealed class MessageOriginChannel : MessageOrigin
{
    public override MessageOriginTypes Type => MessageOriginTypes.Channel;

    public int Date { get; set; }

    public Chat Chat { get; set; }

    public long MessageId { get; set; }

    public string AuthorSignature { get; set; }
}

public sealed class MessageOriginChat : MessageOrigin
{
    public override MessageOriginTypes Type => MessageOriginTypes.Chat;

    public int Date { get; set; }

    public Chat SenderChat { get; set; }

    public string AuthorSignature { get; set; }
}

public sealed class MessageOriginHiddenUser : MessageOrigin
{
    public override MessageOriginTypes Type => MessageOriginTypes.HiddenUser;

    public int Date { get; set; }

    public string SenderUserName { get; set; }
}

public sealed class MessageOriginUser : MessageOrigin
{
    public override MessageOriginTypes Type => MessageOriginTypes.User;

    public int Date { get; set; }

    public User SenderUser { get; set; }
}
