namespace Telegram.BotAPI.Types.AvailableTypes;

public sealed class SwitchInlineQueryChosenChat
{
    public string Query { get; set; }

    public bool AllowUserChats { get; set; }

    public bool AllowBotChats { get; set; }

    public bool AllowGroupChats { get; set; }

    public bool AllowChannelChats { get; set; }
}
