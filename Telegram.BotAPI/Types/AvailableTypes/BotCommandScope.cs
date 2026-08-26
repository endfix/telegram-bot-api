using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

public abstract class BotCommandScope
{
    public abstract BotCommandScopeType Type { get; }
}

public sealed class BotCommandScopeAllChatAdministrators : BotCommandScope
{
    public override BotCommandScopeType Type => BotCommandScopeType.AllChatAdministrators;
}

public sealed class BotCommandScopeAllGroupChats : BotCommandScope
{
    public override BotCommandScopeType Type => BotCommandScopeType.AllGroupChats;
}

public sealed class BotCommandScopeAllPrivateChats : BotCommandScope
{
    public override BotCommandScopeType Type => BotCommandScopeType.AllPrivateChats;
}

public sealed class BotCommandScopeChat : BotCommandScope
{
    public override BotCommandScopeType Type => BotCommandScopeType.Chat;

    public required ChatIdSource ChatId { get; init; }
}

public sealed class BotCommandScopeChatAdministrators : BotCommandScope
{
    public override BotCommandScopeType Type => BotCommandScopeType.ChatAdministrators;

    public required ChatIdSource ChatId { get; init; }
}

public sealed class BotCommandScopeChatMember : BotCommandScope
{
    public override BotCommandScopeType Type => BotCommandScopeType.ChatMember;

    public required ChatIdSource ChatId { get; init; }

    public required long UserId { get; init; }
}

public sealed class BotCommandScopeDefault : BotCommandScope
{
    public override BotCommandScopeType Type => BotCommandScopeType.Default;
}
