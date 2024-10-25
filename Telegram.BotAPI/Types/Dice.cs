namespace Telegram.BotAPI.Types;

// https://core.telegram.org/bots/api#dice
public sealed class Dice
{
    public string Emoji { get; set; }

    public int Value { get; set; }
}
