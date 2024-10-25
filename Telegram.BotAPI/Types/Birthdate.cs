namespace Telegram.BotAPI.Types;

// https://core.telegram.org/bots/api#birthdate
public sealed class Birthdate
{
    public int Day { get; set; }

    public int Month { get; set; }

    public int Year { get; set; }
}
