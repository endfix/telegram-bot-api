namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#botcommandscope
    public abstract class BotCommandScope
    {
        public virtual string Type {  get; set; }

        public class Types
        {
            public const string DEFAULT = "default";

            public const string ALL_PRIVATE_CHATS = "all_private_chats";

            public const string ALL_GROUP_CHATS = "all_group_chats";

            public const string ALL_CHAT_ADMINISTRATORS = "all_chat_administrators";

            public const string CHAT = "chat";

            public const string CHAT_ADMINISTRATORS = "chat_administrators";

            public const string CHAT_MEMBER = "chat_member";
        }

        // https://core.telegram.org/bots/api#botcommandscopedefault
        public class DefaultStruct : BotCommandScope
        {
            public override string Type => Types.DEFAULT;
        }

        // https://core.telegram.org/bots/api#botcommandscopeallprivatechats
        public class AllPrivateChatsStruct : BotCommandScope
        {
            public override string Type => Types.ALL_PRIVATE_CHATS;
        }

        // https://core.telegram.org/bots/api#botcommandscopeallgroupchats
        public class AllGroupChatsStruct : BotCommandScope
        {
            public override string Type => Types.ALL_GROUP_CHATS;
        }

        // https://core.telegram.org/bots/api#botcommandscopeallchatadministrators
        public class AllChatAdministratorsStruct : BotCommandScope
        {
            public override string Type => Types.ALL_CHAT_ADMINISTRATORS;
        }

        // https://core.telegram.org/bots/api#botcommandscopechat
        public class ChatStruct : BotCommandScope
        {
            public override string Type => Types.CHAT;

            public string ChatId { get; set; }
        }

        // https://core.telegram.org/bots/api#botcommandscopechatadministrators
        public class ChatAdministratorsStruct : BotCommandScope
        {
            public override string Type => Types.CHAT_ADMINISTRATORS;

            public string ChatId { get; set; }
        }

        // https://core.telegram.org/bots/api#botcommandscopechatmember
        public class ChatMemberStruct : BotCommandScope
        {
            public override string Type => Types.CHAT_MEMBER;

            public string ChatId { get; set; }

            public long UserId { get; set; }
        }
    }
}
