namespace Endfix.Telegram.BotAPI.Enums;

/// <summary>Identifies the audience to which a bot command scope applies.</summary>
public enum BotCommandScopeType
{
    /// <summary>The default command scope used for all users.</summary>
    Default,

    /// <summary>All private chats.</summary>
    AllPrivateChats,

    /// <summary>All group and supergroup chats.</summary>
    AllGroupChats,

    /// <summary>All administrators of group and supergroup chats.</summary>
    AllChatAdministrators,

    /// <summary>All users in one specific chat.</summary>
    Chat,

    /// <summary>All administrators in one specific chat.</summary>
    ChatAdministrators,

    /// <summary>One specific member of one specific chat.</summary>
    ChatMember
}
