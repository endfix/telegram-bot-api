namespace Telegram.BotAPI.Types;

public abstract class BotCommandScope
{
    public abstract string Type { get; }

    public static class Types
    {
        public const string DEFAULT = "default";

        public const string ALL_PRIVATE_CHATS = "all_private_chats";

        public const string ALL_GROUP_CHATS = "all_group_chats";

        public const string ALL_CHAT_ADMINISTRATORS = "all_chat_administrators";

        public const string CHAT = "chat";

        public const string CHAT_ADMINISTRATORS = "chat_administrators";

        public const string CHAT_MEMBER = "chat_member";
    }
}

public sealed class BotCommandScopeAllChatAdministrators : BotCommandScope
{
    public override string Type => Types.ALL_CHAT_ADMINISTRATORS;
}

public sealed class BotCommandScopeAllGroupChats : BotCommandScope
{
    public override string Type => Types.ALL_GROUP_CHATS;
}

public sealed class BotCommandScopeAllPrivateChats : BotCommandScope
{
    public override string Type => Types.ALL_PRIVATE_CHATS;
}

public sealed class BotCommandScopeChat : BotCommandScope
{
    public override string Type => Types.CHAT;

    public string ChatId { get; set; }
}

public sealed class BotCommandScopeChatAdministrators : BotCommandScope
{
    public override string Type => Types.CHAT_ADMINISTRATORS;

    public string ChatId { get; set; }
}

public class BotCommandScopeChatMember : BotCommandScope
{
    public override string Type => Types.CHAT_MEMBER;

    public string ChatId { get; set; }

    public long UserId { get; set; }
}

public sealed class BotCommandScopeDefault : BotCommandScope
{
    public override string Type => Types.DEFAULT;
}
