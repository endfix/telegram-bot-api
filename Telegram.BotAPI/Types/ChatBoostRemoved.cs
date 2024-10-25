namespace Telegram.BotAPI.Types;

// https://core.telegram.org/bots/api#chatboostremoved
public sealed class ChatBoostRemoved
{
    public Chat Chat { get; set; }

    public string BoostId { get; set; }

    public int RemoveDate { get; set; }

    public ChatBoostSource Source { get; set; }
}
