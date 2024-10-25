namespace Telegram.BotAPI.Types;

// https://core.telegram.org/bots/api#chatlocation
public sealed class ChatLocation
{
    public Location Location { get; set; }

    public string Address { get; set; }
}
