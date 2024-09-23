namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#switchinlinequerychosenchat
    public class SwitchInlineQueryChosenChat
    {
        public string Query { get; set; }

        public bool AllowUserChats { get; set; }

        public bool AllowBotChats { get; set; }

        public bool AllowGroupChats { get; set; }

        public bool AllowChannelChats { get; set; }
    }
}
