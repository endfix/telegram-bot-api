namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#loginurl
    public class LoginUrl
    {
        public string Url { get; set; }

        public string ForwardText { get; set; }

        public string BotUsername { get; set; }

        public bool RequestWriteAccess { get; set; }
    }
}
