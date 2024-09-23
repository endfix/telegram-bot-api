namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#maskposition
    public class MaskPosition
    {
        public string Point { get; set; }

        public float XShift { get; set; }

        public float YShift { get; set; }

        public float Scale { get; set; }
    }
}
