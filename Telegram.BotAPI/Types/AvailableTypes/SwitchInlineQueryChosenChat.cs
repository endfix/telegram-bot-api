namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes which chat types may be selected when switching to inline mode.</summary>
public sealed class SwitchInlineQueryChosenChat
{
    /// <summary>Inline query inserted after the user chooses a chat.</summary>
    public string? Query { get; init; }

    /// <summary>Allows selection of private user chats.</summary>
    public bool? AllowUserChats { get; init; }

    /// <summary>Allows selection of chats with bots.</summary>
    public bool? AllowBotChats { get; init; }

    /// <summary>Allows selection of group and supergroup chats.</summary>
    public bool? AllowGroupChats { get; init; }

    /// <summary>Allows selection of channel chats.</summary>
    public bool? AllowChannelChats { get; init; }
}
