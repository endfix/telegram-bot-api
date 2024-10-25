namespace Telegram.BotAPI.Types
{
    // https://core.telegram.org/bots/api#writeaccessallowed
    public class WriteAccessAllowed
    {
        public bool FromRequest { get; set; }

        public string WebAppName { get; set; }

        public bool FromAttachmentMenu { get; set; }
    }
}
