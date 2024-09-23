namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#dice
    public class Dice
    {
        public string Emoji { get; set; }

        public int Value { get; set; }
    }
}
