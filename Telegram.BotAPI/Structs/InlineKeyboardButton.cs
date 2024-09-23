namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#inlinekeyboardbutton
    public class InlineKeyboardButton
    {
        public string Text { get; set; }

        public string Url { get; set; } = string.Empty;

        public string CallbackData { get; set; } = string.Empty;

        public WebAppInfo WebApp { get; set; }

        public LoginUrl LoginUrl { get; set; }

        public string SwitchInlineQuery { get; set; }

        public string SwitchInlineQueryCurrentChat { get; set; } 

        public SwitchInlineQueryChosenChat SwitchInlineQueryChosenChat { get; set; }

        public CallbackGame CallbackGame { get; set; }

        public bool Pay { get; set; }
    }
}
