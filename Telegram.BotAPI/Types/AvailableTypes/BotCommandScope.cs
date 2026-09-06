using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes the scope to which bot commands are applied.
/// </summary>
public abstract class BotCommandScope
{
    /// <summary>Gets the type of the command scope.</summary>
    public abstract BotCommandScopeType Type { get; }
}

/// <summary>Represents the scope covering all chat administrators.</summary>
public sealed class BotCommandScopeAllChatAdministrators : BotCommandScope
{
    /// <inheritdoc />
    public override BotCommandScopeType Type => BotCommandScopeType.AllChatAdministrators;
}

/// <summary>Represents the scope covering all group and supergroup chats.</summary>
public sealed class BotCommandScopeAllGroupChats : BotCommandScope
{
    /// <inheritdoc />
    public override BotCommandScopeType Type => BotCommandScopeType.AllGroupChats;
}

/// <summary>Represents the scope covering all private chats.</summary>
public sealed class BotCommandScopeAllPrivateChats : BotCommandScope
{
    /// <inheritdoc />
    public override BotCommandScopeType Type => BotCommandScopeType.AllPrivateChats;
}

/// <summary>Represents the scope covering a specific chat.</summary>
public sealed class BotCommandScopeChat : BotCommandScope
{
    /// <inheritdoc />
    public override BotCommandScopeType Type => BotCommandScopeType.Chat;

    /// <summary>Unique identifier for the target chat or username of the target supergroup.</summary>
    public required ChatIdSource ChatId { get; init; }
}

/// <summary>Represents the scope covering all administrators of a specific chat.</summary>
public sealed class BotCommandScopeChatAdministrators : BotCommandScope
{
    /// <inheritdoc />
    public override BotCommandScopeType Type => BotCommandScopeType.ChatAdministrators;

    /// <summary>Unique identifier for the target chat or username of the target supergroup.</summary>
    public required ChatIdSource ChatId { get; init; }
}

/// <summary>Represents the scope covering a specific member of a specific chat.</summary>
public sealed class BotCommandScopeChatMember : BotCommandScope
{
    /// <inheritdoc />
    public override BotCommandScopeType Type => BotCommandScopeType.ChatMember;

    /// <summary>Unique identifier for the target chat or username of the target supergroup.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>Unique identifier of the target user.</summary>
    public required long UserId { get; init; }
}

/// <summary>Represents the default scope of bot commands.</summary>
public sealed class BotCommandScopeDefault : BotCommandScope
{
    /// <inheritdoc />
    public override BotCommandScopeType Type => BotCommandScopeType.Default;
}
