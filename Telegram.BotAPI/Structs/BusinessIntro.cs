namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#businessintro
    public class BusinessIntro
    {
        public string Name { get; set; }

        public string Message { get; set; }

        public Sticker Sticker { get; set; }
    }
}
