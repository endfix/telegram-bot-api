using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public abstract class BotCommandScope
{
    public abstract BotCommandScopeTypes Type { get; }
}

public sealed class BotCommandScopeAllChatAdministrators : BotCommandScope
{
    public override BotCommandScopeTypes Type => BotCommandScopeTypes.AllChatAdministrators;
}

public sealed class BotCommandScopeAllGroupChats : BotCommandScope
{
    public override BotCommandScopeTypes Type => BotCommandScopeTypes.AllGroupChats;
}

public sealed class BotCommandScopeAllPrivateChats : BotCommandScope
{
    public override BotCommandScopeTypes Type => BotCommandScopeTypes.AllPrivateChats;
}

public sealed class BotCommandScopeChat : BotCommandScope
{
    public override BotCommandScopeTypes Type => BotCommandScopeTypes.Chat;

    public object ChatId { get; set; }
}

public sealed class BotCommandScopeChatAdministrators : BotCommandScope
{
    public override BotCommandScopeTypes Type => BotCommandScopeTypes.ChatAdministrators;

    public object ChatId { get; set; }
}

public class BotCommandScopeChatMember : BotCommandScope
{
    public override BotCommandScopeTypes Type => BotCommandScopeTypes.ChatMember;

    public object ChatId { get; set; }

    public long UserId { get; set; }
}

public sealed class BotCommandScopeDefault : BotCommandScope
{
    public override BotCommandScopeTypes Type => BotCommandScopeTypes.Default;
}
