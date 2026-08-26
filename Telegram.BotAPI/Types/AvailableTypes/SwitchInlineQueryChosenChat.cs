namespace Endfix.Telegram.BotAPI.Types;

public sealed class SwitchInlineQueryChosenChat
{
    public string? Query { get; init; }

    public bool? AllowUserChats { get; init; }

    public bool? AllowBotChats { get; init; }

    public bool? AllowGroupChats { get; init; }

    public bool? AllowChannelChats { get; init; }
}
